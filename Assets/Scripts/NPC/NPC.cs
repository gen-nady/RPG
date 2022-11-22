using UnityEngine;

namespace NPC
{
    public abstract class NPC : MonoBehaviour
    {
        protected int _healht;
        public IMovable _movable;
        public ISpeakble _speakble;
        
        protected abstract void InitNPC();

        public void Speak()
        {
            _speakble.Speak();
        }

        protected void Move(Vector3 direction)
        {
            _movable.Move(direction);
        }
    }
}