using UnityEngine;
using Zenject;

namespace QuestSystem
{
    public class PlayerQuest : MonoBehaviour
    {
        private Quest _playerQuest;
        [Inject] private PlayerQuestUI _playerQuestUI;
        public Quest CurrentQuestPlayer => _playerQuest;
        public void DeadEnemy<TypeDead>()
        {
            if (_playerQuest != null)
            {
                _playerQuest.ChangeProgressQuest<TypeDead>();
                _playerQuestUI.ChangeProgress(_playerQuest);
            }
        }
        
        public void PickUp<FindObject>()
        {
            if (_playerQuest != null)
            {
                _playerQuest.ChangeProgressQuest<FindObject>();
                _playerQuestUI.ChangeProgress(_playerQuest);
            }
        }
        
        private void OnEnable()
        {
            QuestGiver.AddQuestToPlayer += SetQuest;
            QuestGiver.QuestCompleted += GetBonuses;
        }

        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= SetQuest;
            QuestGiver.QuestCompleted -= GetBonuses;
        }
        
        private void GetBonuses(Quest quest)
        {
            Debug.Log($"Получено опыта: {quest.Expirience}");
            Debug.Log($"Получено золота: {quest.Gold}");
        }
        private void SetQuest(Quest quest)
        {
            _playerQuest = quest;
        }
    }
}