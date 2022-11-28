using NPC;
using UnityEngine;

namespace QuestSystem
{
    public abstract class QuestInfo : ScriptableObject
    {
        [SerializeField] private int _idQuest;
        [SerializeField] private string _nameQuest;
        [SerializeField] private string _discription;
        private CurrentStateQuest _currentStateQuest;
        public string Discription => _discription;
        public string Name => _nameQuest;
        public CurrentStateQuest CurrentStateQuest => _currentStateQuest;
        public abstract string CurrentProgress;
        private IMovable movableImplementation;

        public void ChangeQuestState(CurrentStateQuest state)
        {
            _currentStateQuest = state;
        }
    }
}