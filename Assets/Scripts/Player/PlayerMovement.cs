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
            if (_fixedJoystick.Direction.x != 0)
                transform.Rotate(new Vector3(0,_fixedJoystick.Direction.x,0)  * _rotateSpeed * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            Vector3 moveVector = transform.TransformDirection(new Vector3(_fixedJoystick.Direction.x, 0, _fixedJoystick.Direction.y > 0 ? _fixedJoystick.Direction.y : _fixedJoystick.Direction.y/2)* _speed );
            _rigidbody.velocity = new Vector3( moveVector.x , _gravityModifer,moveVector.z) * Time.fixedDeltaTime;
            AnimationPlayer();
        }

        public void Jump()
        {
            if (Physics.CheckSphere(_groundCheck.position, _radiusCheckGround, _groundMask))
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
                _animator.SetTrigger("Jump");
            }
            
        }
        
        private void AnimationPlayer()
        {
            if ((_fixedJoystick.Direction.x > 0 || _fixedJoystick.Direction.y != 0))
            {
                _animator.SetFloat("Run",
                    _fixedJoystick.Direction.y > 0
                        ? Mathf.Max(Mathf.Abs(_rigidbody.velocity.x), Mathf.Abs(_rigidbody.velocity.z))
                        : 0);
                if (_currentStatePlayer != CurrentStatePlayer.run)
                {
                    _animator.ResetTrigger("Idle");
                    _animator.SetTrigger("StartRun");
                    _currentStatePlayer = CurrentStatePlayer.run;
                }
            }
            if((_fixedJoystick.Direction.x == 0 && _fixedJoystick.Direction.y == 0) && (_currentStatePlayer != CurrentStatePlayer.idle))
            {
                _animator.SetTrigger("Idle");
                _currentStatePlayer = CurrentStatePlayer.idle;
            }
        }
    }
}
