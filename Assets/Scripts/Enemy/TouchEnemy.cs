
using System;
using QuestSystem;

namespace Enemy
{
    public class TouchEnemy : MainEnemy
    {
        public void Kill()
        {
            _playerQuest.DeadEnemy<TouchEnemy>();
            Destroy(gameObject);
        }
    }
}