using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class PlayerQuest : Singleton<PlayerQuest>
    {
        private QuestInfo _playerQuest;
        private QuestVisibleModel _questVisibleModel;

        private void Start()
        {
            Constructor();
        }

        private void Constructor()
        {
            _questVisibleModel = QuestVisibleModel.Instance;
        }
        public void SetQuest(QuestInfo quest)
        {
            _playerQuest = quest;
            _questVisibleModel.CurrentProgress
        }
    }
}