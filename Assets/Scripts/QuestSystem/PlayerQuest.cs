using System;
using System.Collections.Generic;
using Enemy;
using TMPro;
using UnityEngine;
using Zenject;

namespace QuestSystem
{
    public class PlayerQuest : MonoBehaviour
    {
        [Inject] private PlayerQuestUI _playerQuestUI;
        private Quest _playerQuest;
        //public static event Action<Quest> QuestChange; 
        public void DeadEnemy<TypeDead>()
        {
            var isComplete = _playerQuest.ProgressQuest<TypeDead>();
            _playerQuestUI.ChangeProgress(_playerQuest);
        }
        
        private void OnEnable()
        {
            QuestGiver.AddQuestToPlayer += SetQuest;
        }

        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= SetQuest;
        }
        
        private void SetQuest(Quest quest)
        {
            _playerQuest = quest;
        }
    }
}