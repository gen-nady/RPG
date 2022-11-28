using UnityEngine;

namespace NPC
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class SilentMoveNpc : NPCObject
    {
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _speed;
        [SerializeField] private float _defaultTimeRotate;

        private Animator _animator;
        private Rigidbody _rigibody;
        private float _timeToRotate;
        
        private void Awake()
        {
            _timeToRotate = _defaultTimeRotate;
            _rigibody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            InitNPC();
            //_animator.SetTrigger("Walk");
        }

        protected override void InitNPC()
        {
            _speakble = new NoSpeakNPC();
            _movable = new FreeMoveNPC(_rigibody, _speed);
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
                _movable = new StayNPC();
            if (Input.GetKey(KeyCode.D))
                _movable = new FreeMoveNPC(_rigibody, _speed);
            // _timeToRotate -= Time.deltaTime;
            // if (_timeToRotate <= 0)
            // {
            //     transform.RotateAround(transform.position, transform.up, 180f);
            //     _direction *= -1;
            //     _timeToRotate = _defaultTimeRotate;
            // }
            Movement();
        }
        
        private void Movement()
        {
            Move(_direction);
        }
    }
}