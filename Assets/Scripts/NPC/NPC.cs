using UnityEngine;
using Helper;

namespace NPC
{
    public abstract class NPC : MonoBehaviour
    {
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