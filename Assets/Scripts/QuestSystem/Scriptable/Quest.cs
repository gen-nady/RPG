using System;
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
        public string Name => _name;
        public string Discription => _discription;
        public abstract bool ProgressQuest<Type>();
        public abstract string CurrentProgress();
        public abstract void Reset();
    }
}