using NPC;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "Quests", menuName = "Quests/Quest", order = 0)]
    public class QuestToKill : Quest
    {
        public int CountToKill;
        public int CurrentToKill;
        public NPCObject TypeKill;
        public override bool IsCompleted()
        {
            return CountToKill == CurrentToKill;
        }

        public override string CurrentProgress()
        {
            return $"Убито {typeof(NPCObject)} {CurrentToKill} из {CountToKill}";
        }
    }
}