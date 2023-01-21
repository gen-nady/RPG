using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class QuestGiverUI : MonoBehaviour
    {
        [Header("Получение квеста")]
        [SerializeField] private TextMeshProUGUI _desriptionText;
        [SerializeField] private GameObject _questPanel;
        [SerializeField] private Button _agreeQuestButton;
        [Header("Сдача квеста")]
        [SerializeField] private TextMeshProUGUI _bonusesText;
        [SerializeField] private GameObject _bonusesPanel;
        [SerializeField] private Button _agreeBonusesButton;
        public void SetQuestText(Quest quest, Action agreeAction)
        {
            _questPanel.SetActive(true);
            _desriptionText.text = quest.Discription;
            _agreeQuestButton.onClick.AddListener(() => agreeAction?.Invoke());
        }
        
        public void CompletedQuest(Quest quest, Action agreeAction)
        {
            _bonusesPanel.SetActive(true);
            _bonusesText.text = $"Золото х{quest.Gold} \n" +
                                $"Опыт х{quest.Expirience}";
            _agreeBonusesButton.onClick.AddListener(() => agreeAction?.Invoke());
        }
        public void CloseBonusesPanel()
        {
            _agreeBonusesButton.onClick.RemoveAllListeners();
            _bonusesPanel.SetActive(false);
        }
        public void CloseQuestText()
        {
            _agreeQuestButton.onClick.RemoveAllListeners();
            _questPanel.SetActive(false);
        }
    }
}