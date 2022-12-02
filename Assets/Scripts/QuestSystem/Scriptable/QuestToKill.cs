using NPC;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "Quests", menuName = "Quests/Quest", order = 0)]
    public class QuestToKill : Quest
    {
        [SerializeField] private int _countToKill;
        [SerializeField] private int _currentToKill;
        [SerializeField] private NPCObject _typeKill;
        public override bool IsCompleted()
        {
            return _countToKill == _currentToKill;
        }

        public override string CurrentProgress()
        {
            return $"Убито {typeof(NPCObject)} {_currentToKill} из {_countToKill}";
        }
    }
}