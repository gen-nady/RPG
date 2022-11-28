using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;

namespace QuestSystem
{
    public class QuestSystem : MonoBehaviour
    {
        [SerializeField] private QuestToKill _quest;
        [SerializeField] private GameObject _activeQuest;
        private QuestVisibleModel _questVisibleModel;
        private PlayerQuest _playerQuest;
        private void Start()
        {
            Constructor();
            CheckForActiveQuest();
        }

        private void Constructor()
        {
            _questVisibleModel = QuestVisibleModel.Instance;
            _playerQuest = PlayerQuest.Instance;
        }

        private void CheckForActiveQuest()
        {
            _activeQuest.SetActive(_quest.CurrentStateQuest == CurrentStateQuest.active);
        }

        private void AddQuestToPlayer()
        {
            _quest.ChangeQuestState(CurrentStateQuest.active);
            _playerQuest.SetQuest(_quest);
            CheckForActiveQuest();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                _questVisibleModel.SetQuestText(_quest, AddQuestToPlayer);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                _questVisibleModel.CloseQuestText();
            }
        }
    }
}