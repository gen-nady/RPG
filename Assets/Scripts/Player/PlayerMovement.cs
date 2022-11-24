using System.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Jump")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _radiusCheckGround;
        [SerializeField] private float _jumpForce;
        private bool grounded;
        private bool isJump;
        [Header("Movement")]
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private Transform orientation;
        [SerializeField] private float _gravity;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        private Vector3 _moveDirection;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private CurrentStatePlayer _currentStatePlayer;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _currentStatePlayer = CurrentStatePlayer.idle;
            _rigidbody.freezeRotation = true;
        }

        private void Update()
        {
            // ground check
            grounded = Physics.CheckSphere(_groundCheck.position, _radiusCheckGround, _groundMask);
            if (_fixedJoystick.Direction.x != 0)
                transform.Rotate(new Vector3(0, _fixedJoystick.Direction.x, 0) * _rotateSpeed * Time.deltaTime);
            SpeedControl();
            if (grounded)
            {
                isJump = false;
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
            }
            else
            {
                Debug.Log("Зашло");
                _rigidbody.AddForce(Vector3.down * _gravity, ForceMode.Force);
            }
        }

        private void FixedUpdate()
        {
            MovePlayer();
            AnimationPlayer();
        }

        private void MovePlayer()
        {
            _moveDirection = (orientation.forward * _fixedJoystick.Vertical + orientation.right * _fixedJoystick.Horizontal);
            if(_fixedJoystick.Vertical > 0)
                _rigidbody.AddForce(_moveDirection.normalized * _moveSpeed * 10, ForceMode.Force);
            else
                _rigidbody.AddForce(_moveDirection.normalized * _moveSpeed, ForceMode.Force);
            if(_fixedJoystick.Direction.x == 0 && _fixedJoystick.Direction.y == 0)
                _rigidbody.velocity =new Vector3(0f, _rigidbody.velocity.y,0f);
        }

        private void SpeedControl()
        {
            var flatVel = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
            
            if (flatVel.magnitude > _moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * _moveSpeed;
                _rigidbody.velocity = new Vector3(limitedVel.x, _rigidbody.velocity.y, limitedVel.z);
            }
        }
        
        private async void Jump()
        {
            if (grounded)
            {
                isJump = true;
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
                _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
                _animator.SetTrigger("Jump");
                await Task.Delay(500);
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
                _rigidbody.AddForce(Vector3.down * _gravity*8, ForceMode.Impulse);
            }
        }
        private void AnimationPlayer()
        {
            if (_fixedJoystick.Direction.x > 0 || _fixedJoystick.Direction.y != 0)
            {
                _animator.SetFloat("Run",
                    _fixedJoystick.Direction.y > 0
                        ? Mathf.Max(Mathf.Abs(_fixedJoystick.Direction.x), Mathf.Abs(_fixedJoystick.Direction.y))
                        : 0);
                if (_currentStatePlayer != CurrentStatePlayer.run)
                {
                    _animator.ResetTrigger("Idle");
                    _animator.SetTrigger("StartRun");
                    _currentStatePlayer = CurrentStatePlayer.run;
                }
            }
            if(_fixedJoystick.Direction.x == 0 && _fixedJoystick.Direction.y == 0 && _currentStatePlayer != CurrentStatePlayer.idle)
            {
                _animator.SetTrigger("Idle");
                _currentStatePlayer = CurrentStatePlayer.idle;
            }
        }
    }
}













//     [Header("Jump")]
    //     [SerializeField] private Transform _groundCheck;
    //     [SerializeField] private LayerMask _groundMask;
    //     [SerializeField] private float _jumpForce;
    //     [SerializeField] private float _radiusCheckGround;
    //     [SerializeField] private float _gravityModifer;
    //     [Header("Move")]
    //     [SerializeField] private FixedJoystick _fixedJoystick;
    //     [SerializeField] private float _speed;
    //     [SerializeField] private float _rotateSpeed;
    //     
    //     private Animator _animator;
    //     private Rigidbody _rigidbody;
    //     private CurrentStatePlayer _currentStatePlayer;
    //
    //     private void Awake()
    //     {
    //         _rigidbody = GetComponent<Rigidbody>();
    //         _animator = GetComponent<Animator>();
    //         _currentStatePlayer = CurrentStatePlayer.idle;
    //     }
    //
    //     private void Update()
    //     {
    //         if (_fixedJoystick.Direction.x != 0)
    //             transform.Rotate(new Vector3(0,_fixedJoystick.Direction.x,0)  * _rotateSpeed * Time.deltaTime);
    //     }
    //
    //     private void FixedUpdate()
    //     {
    //      
    //         Vector3 moveVector = (transform.TransformDirection(new Vector3(_fixedJoystick.Direction.x, 0, 
    //             _fixedJoystick.Direction.y > 0 ? _fixedJoystick.Direction.y : _fixedJoystick.Direction.y/2)) * _speed);
    //         Debug.Log(moveVector);
    //         _rigidbody.AddForce(new Vector3( moveVector.x,_gravityModifer, moveVector.z), ForceMode.Acceleration);
    //         AnimationPlayer();
    //     }
    //
    //     public void Jump()
    //     {
    //         if (Physics.CheckSphere(_groundCheck.position, _radiusCheckGround, _groundMask))
    //         {
    //             _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    //             _animator.SetTrigger("Jump");
    //         }
    //         
    //     }
    //     
    //     private void AnimationPlayer()
    //     {
    //         if ((_fixedJoystick.Direction.x > 0 || _fixedJoystick.Direction.y != 0))
    //         {
    //             _animator.SetFloat("Run",
    //                 _fixedJoystick.Direction.y > 0
    //                     ? Mathf.Max(Mathf.Abs(_rigidbody.velocity.x), Mathf.Abs(_rigidbody.velocity.z))
    //                     : 0);
    //             if (_currentStatePlayer != CurrentStatePlayer.run)
    //             {
    //                 _animator.ResetTrigger("Idle");
    //                 _animator.SetTrigger("StartRun");
    //                 _currentStatePlayer = CurrentStatePlayer.run;
    //             }
    //         }
    //         if((_fixedJoystick.Direction.x == 0 && _fixedJoystick.Direction.y == 0) && (_currentStatePlayer != CurrentStatePlayer.idle))
    //         {
    //             _animator.SetTrigger("Idle");
    //             _currentStatePlayer = CurrentStatePlayer.idle;
    //         }
    //     }
    // }

