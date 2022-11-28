using NPC;
using UnityEngine;

namespace QuestSystem
{
    public class Quest
    {
        public int Id;
        public QuestInfo Info;
        public TypeQuest Type;
        public int CountToKill;
        public NPCObject TypeKill;
    }

    public enum TypeQuest
    {
        ToKill,
        ToSay,
        ToFind
    }
}