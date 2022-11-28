using NPC;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "Quests", menuName = "Quests/QuestInfo", order = 0)]
    public class QuestInfo : ScriptableObject
    {
        [SerializeField] private int _idQuest;
        [SerializeField] private string _name;
        [SerializeField] private string _discription;
        [SerializeField] private int _expirience;
        [SerializeField] private int _gold;
    }
}