using UnityEngine;

namespace NPC
{
    public abstract class NPC : MonoBehaviour
    {
        protected int _healht;
        protected IMovable _movable;
        protected ISpeakble _speakble;
        
        protected abstract void InitNPC();

        protected void Speak()
        {
            _speakble.Speak();
        }

        protected void Move(Vector3 direction)
        {
            _movable.Move(direction);
        }
    }
}