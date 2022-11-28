using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class QuestVisibleModel : Singleton<QuestVisibleModel>
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
            _desriptionText.text = quest.Discription;
            _questPanel.SetActive(true);
            if (quest.CurrentStateQuest != CurrentStateQuest.inProgress)
            {
                _agreeButton.gameObject.SetActive(true);
                _agreeButton.onClick.AddListener( () => agreeAction?.Invoke());
            }
            else
            {
                _agreeButton.gameObject.SetActive(false);
            }
        }
        public void CloseQuestText()
        {
            _agreeButton.onClick.RemoveAllListeners();
            _questPanel.SetActive(false);
        }

        public void SetCurrentQuest(QuestInfo questInfo)
        {
            _currentQuestText.text = questInfo.Discription;
            _progressCurrentQuest.text = questInfo.CurrentProgress;
        }
    }
}