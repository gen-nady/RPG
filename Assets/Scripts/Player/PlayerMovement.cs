using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody),typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Jump")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _radiusCheckGround;
        [SerializeField] private float _jumpForce;
        private bool isJump;
        private bool isFall;
        private bool grounded => Physics.CheckSphere(_groundCheck.position, _radiusCheckGround,_groundMask);
        private readonly float timeToFall = 0.3f;
        private float timerToFall;
        [Header("Movement")]
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private float _gravity;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        private Vector3 _moveDirection;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private CurrentStatePlayer _currentStatePlayer;
        //Helper
        private readonly int _run = Animator.StringToHash("Run");
        private readonly int _idle = Animator.StringToHash("Idle");
        private readonly int _startRun = Animator.StringToHash("StartRun");
        private readonly int _jump = Animator.StringToHash("Jump");
        private readonly int _fall = Animator.StringToHash("Fall");
        private Vector3 zeroGravity => new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        private float currentSpeedRunAnimation => _fixedJoystick.Direction.y > 0
            ? Mathf.Max(Mathf.Abs(_fixedJoystick.Direction.x), Mathf.Abs(_fixedJoystick.Direction.y))
            : 0;
        #region Mono
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _currentStatePlayer = CurrentStatePlayer.idle;
            _rigidbody.freezeRotation = true;
            timerToFall = timeToFall;
        }

        private void Update()
        {
            SpeedControl();
            Rotate();
            CheckGround();
        }
        
        private void FixedUpdate()
        {
            Move();
            AnimationMovePlayer();
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(_groundCheck.position, _radiusCheckGround);
        }
        #endregion

        #region Move
        private void Move()
        {
            _moveDirection = (transform.forward * _fixedJoystick.Vertical + transform.right * _fixedJoystick.Horizontal);
            if(_fixedJoystick.Vertical > 0f)
                _rigidbody.AddForce(_moveDirection.normalized * _moveSpeed * 10, ForceMode.Force);
            else
                _rigidbody.AddForce(_moveDirection.normalized * _moveSpeed, ForceMode.Force);
            if(_fixedJoystick.Direction.x == 0f && _fixedJoystick.Direction.y == 0f)
                _rigidbody.velocity =new Vector3(0f, _rigidbody.velocity.y,0f);
        }

        private void SpeedControl()
        {
            if (zeroGravity.magnitude > _moveSpeed)
            {
                Vector3 limitedVel = zeroGravity.normalized * _moveSpeed;
                _rigidbody.velocity = new Vector3(limitedVel.x, _rigidbody.velocity.y, limitedVel.z);
            }
        }

        private void Rotate()
        {
            if (_fixedJoystick.Direction.x != 0f)
                transform.Rotate(new Vector3(0f, _fixedJoystick.Direction.x, 0f) * _rotateSpeed * Time.deltaTime);
        }
        private void AnimationMovePlayer()
        {
            if (_fixedJoystick.Direction.x > 0 || _fixedJoystick.Direction.y != 0)
            {
                _animator.SetFloat(_run,currentSpeedRunAnimation);
                if (_currentStatePlayer != CurrentStatePlayer.run)
                {
                    _animator.ResetTrigger(_idle);
                    _animator.SetTrigger(_startRun);
                    _currentStatePlayer = CurrentStatePlayer.run;
                }
            }
            if(_fixedJoystick.Direction.x == 0 && _fixedJoystick.Direction.y == 0 && _currentStatePlayer != CurrentStatePlayer.idle)
            {
                _animator.SetTrigger(_idle);
                _currentStatePlayer = CurrentStatePlayer.idle;
            }
        }
        #endregion

        #region Jump
        private void CheckGround()
        {
            if (grounded)
            {
                timerToFall = timeToFall;
                _rigidbody.velocity = zeroGravity;
                if (isJump || isFall)
                {
                    isJump = false;
                    isFall = false;
                    _animator.ResetTrigger(_fall);
                    _animator.ResetTrigger(_jump);
                    if (_currentStatePlayer == CurrentStatePlayer.run)
                    {
                        _animator.ResetTrigger(_idle);
                        _animator.SetFloat(_run,currentSpeedRunAnimation);
                        _animator.SetTrigger(_startRun);
                    }
                    else if (_currentStatePlayer == CurrentStatePlayer.idle)
                    {
                        _animator.SetTrigger(_idle);
                    }
                }
            }
            else
            {
                timerToFall -= Time.deltaTime;
                _rigidbody.AddForce(Vector3.down * _gravity, ForceMode.Force);
                if (!isFall && timerToFall < 0f && !isJump)
                {
                    _animator.SetTrigger(_fall);
                    isFall = true;
                }
            }
        }
        
        private void Jump()
        {
            if (grounded)
            {
                StartCoroutine(JumpWait());
                _rigidbody.velocity = zeroGravity;
                _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
                _animator.SetTrigger(_jump);
            }
        }
        
        private IEnumerator JumpWait()
        {
            yield return new WaitForSeconds(0.2f);
            isJump = true;
        }
        #endregion
    }
}
