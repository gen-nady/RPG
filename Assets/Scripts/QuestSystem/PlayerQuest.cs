using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class PlayerQuest : Singleton<PlayerQuest>
    {
        private QuestInfo _playerQuest;
        private QuestGiverUI questGiverUI;

        private void Start()
        {
            Constructor();
        }
        
        private void Constructor()
        {
            questGiverUI = QuestGiverUI.Instance;
        }
        public void SetQuest(QuestInfo quest)
        {
            _playerQuest = quest;
            //questGiverUI.CurrentProgress
        }
        
    }
}