using NPC;
using UnityEngine;

namespace QuestSystem
{
   
    public abstract class Quest : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private int _idQuest;
        [SerializeField] private string _name;
        [SerializeField] private string _discription;
        [SerializeField] private int _expirience;
        [SerializeField] private int _gold;

        public string Discription => _discription;
        
        public abstract bool IsCompleted();

        public abstract string CurrentProgress();
    }
}