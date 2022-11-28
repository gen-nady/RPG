using NPC;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "Quests", menuName = "Quests/QuestToKill", order = 0)]
    public class QuestToKill : QuestInfo
    {
        [SerializeField] private int _countToKill;
        private int _currentToKill;
        [SerializeField] private NPCObject typeKill;

        public override string CurrentProgress => $"{_currentToKill}/{_countToKill}";
        public void AddToKill()
        {
            _currentToKill++;
        }

        public bool IsCompleted()
        {
            return _countToKill == _currentToKill;
        }
        
    }
}