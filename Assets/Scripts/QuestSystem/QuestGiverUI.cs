using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class QuestGiverUI : Singleton<QuestGiverUI>
    {
        [Header("получение квеста")]
        [SerializeField] private TextMeshProUGUI _desriptionText;
        [SerializeField] private GameObject _questPanel;
        [SerializeField] private Button _agreeButton;

        [Header("Отображение текущего квеста")]
        [SerializeField] private TextMeshProUGUI _currentQuestText;
        [SerializeField] private TextMeshProUGUI _progressCurrentQuest;
        
        
        public void SetQuestText(QuestInfo quest, Action agreeAction)
        {
         
        }
        public void CloseQuestText()
        {
            _agreeButton.onClick.RemoveAllListeners();
            _questPanel.SetActive(false);
        }

        public void SetCurrentQuest(QuestInfo questInfo)
        {
          
        }
    }
}