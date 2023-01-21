using Enemy;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "Quests", menuName = "Quests/Quest", order = 0)]
    public class QuestToKill : Quest
    {
        [SerializeField] private MainEnemy _typeKill;
        [SerializeField] private string _localizedMaimEnemy;
        [SerializeField] private int _countToKill;
        [SerializeField] private int _currentToKill = 0;

        private void OnEnable()
        {
            Reset();
        }

        public override void ChangeProgressQuest<TypeKill>()
        {
            if (_typeKill is TypeKill)
            {
                _currentToKill++;
            }
        }

        public override bool IsCompleteQuest()
        {
            return _countToKill == _currentToKill;
        }

        public override string CurrentProgress()
        {
            return IsCompleteQuest() 
                ? "Можете сдать квест!" 
                : $"Убито {_localizedMaimEnemy} {_currentToKill} из {_countToKill}";
        }

        public override void Reset()
        {
            _currentToKill = 0;
        }
    }
}