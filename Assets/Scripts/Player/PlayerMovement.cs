using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private float _speed;
        private Animator _animator;
        private Rigidbody _rigidbody;
        private CurrentStatePlayer _currentStatePlayer;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _currentStatePlayer = CurrentStatePlayer.idle;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(_fixedJoystick.Direction.x, 0, _fixedJoystick.Direction.y) * _speed * Time.fixedDeltaTime;
            if ((_fixedJoystick.Direction.x > 0 || _fixedJoystick.Direction.y > 0) && _currentStatePlayer != CurrentStatePlayer.run)
            {
                _animator.ResetTrigger("Idle");
                _animator.SetTrigger("Run");
                _currentStatePlayer = CurrentStatePlayer.run;
            }
            if((_fixedJoystick.Direction.x == 0 && _fixedJoystick.Direction.y == 0) &&_currentStatePlayer != CurrentStatePlayer.idle)
            {
                _animator.SetTrigger("Idle");
                _currentStatePlayer = CurrentStatePlayer.idle;
            }
        }
    }
}
