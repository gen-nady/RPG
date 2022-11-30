using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestSystem
{
    public class PlayerQuest : Singleton<PlayerQuest>
    {
        private Quest _playerQuest;
        private QuestGiverUI questGiverUI;
        [SerializeField] private TextMeshProUGUI _desriptionText;
        private void Start()
        {
            Constructor();
        }
        
        private void Constructor()
        {
            questGiverUI = QuestGiverUI.Instance;
        }

        public void SetQuest(Quest quest)
        {
            _playerQuest = quest;
            _desriptionText.text = _playerQuest.CurrentProgress();
        }
    }
}