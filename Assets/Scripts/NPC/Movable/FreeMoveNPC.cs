using UnityEngine;

namespace NPC
{
    public class FreeMoveNPC : IMovable
    {
        private Rigidbody _rigidbody;
        private float _speed;

        public FreeMoveNPC(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction * _speed * Time.fixedDeltaTime;
        }
    }
}