using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Jump")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _radiusCheckGround;
        [SerializeField] private float _gravityModifer;
        [Header("Move")]
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotateSpeed;
        
        private Animator _animator;
        private Rigidbody _rigidbody;
        private CurrentStatePlayer _currentStatePlayer;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _currentStatePlayer = CurrentStatePlayer.idle;
        }

        private void Update()
        {
#if (UNITY_EDITOR)
            if(Input.GetKey(KeyCode.Space))
                Jump();
            if (Input.GetAxis("Horizontal") != 0)
                transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal"),0)  * _rotateSpeed * Time.deltaTime);
#else
            if (_fixedJoystick.Direction.x != 0)
                transform.Rotate(new Vector3(0,_fixedJoystick.Direction.x,0)  * _rotateSpeed * Time.deltaTime);
#endif
                
        }

        private void FixedUpdate()
        {
#if (UNITY_EDITOR)
            Vector3 moveVector = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed);
#else
            Vector3 moveVector = transform.TransformDirection(new Vector3(_fixedJoystick.Direction.x, 0, _fixedJoystick.Direction.y) * _speed);
#endif
            _rigidbody.velocity = new Vector3(moveVector.x, _gravityModifer,moveVector.z) * Time.fixedDeltaTime;
            AnimationPlayer();
        }

        public void Jump()
        {
            if (Physics.CheckSphere(_groundCheck.position, _radiusCheckGround, _groundMask))
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _animator.SetTrigger("Jump");
            }
            
        }
        
        private void AnimationPlayer()
        {
#if (UNITY_EDITOR)
            if ((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") != 0) && (_currentStatePlayer != CurrentStatePlayer.run))
#else
            if ((_fixedJoystick.Direction.x > 0 || _fixedJoystick.Direction.y != 0) && (_currentStatePlayer != CurrentStatePlayer.run))
#endif
            {
                _animator.ResetTrigger("Idle");
                _animator.SetTrigger("Run");
                _currentStatePlayer = CurrentStatePlayer.run;
            }
#if (UNITY_EDITOR)
            if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) && (_currentStatePlayer != CurrentStatePlayer.idle))
#else
            if((_fixedJoystick.Direction.x == 0 && _fixedJoystick.Direction.y == 0) && (_currentStatePlayer != CurrentStatePlayer.idle))
#endif
            {
                _animator.SetTrigger("Idle");
                _currentStatePlayer = CurrentStatePlayer.idle;
            }
        }
    }
}
