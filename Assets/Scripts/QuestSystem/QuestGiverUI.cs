using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class QuestGiverUI : MonoBehaviour
    {
        [Header("получение квеста")]
        [SerializeField] private TextMeshProUGUI _desriptionText;
        [SerializeField] private GameObject _questPanel;
        [SerializeField] private Button _agreeButton;

        private void Start()
        {
            QuestGiver.SetDescriprionQuest += SetQuestText;
        }

        private void OnDestroy()
        {
            QuestGiver.SetDescriprionQuest -= SetQuestText;
        }

        private void SetQuestText(Quest quest, Action agreeAction)
        {
            _questPanel.SetActive(true);
            _desriptionText.text = quest.Discription;
            _agreeButton.onClick.AddListener(() => agreeAction?.Invoke());
        }
        public void CloseQuestText()
        {
            _agreeButton.onClick.RemoveAllListeners();
            _questPanel.SetActive(false);
        }
    }
}