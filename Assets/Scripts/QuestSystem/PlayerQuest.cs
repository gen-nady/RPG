using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestSystem
{
    public class PlayerQuest : Singleton<PlayerQuest>
    {
        [SerializeField] private TextMeshProUGUI _desriptionText;
        private Quest _playerQuest;

        private void Start()
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
            _desriptionText.text = _playerQuest.CurrentProgress();
        }
    }
}