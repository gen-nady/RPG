using TMPro;
using UnityEngine;

namespace QuestSystem
{
    public class PlayerQuestUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentProgressQuest;
        [SerializeField] private TextMeshProUGUI _nameQuest;
        private void Start()
        {
            QuestGiver.AddQuestToPlayer += SetInfoOrQuest;
        }

        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= SetInfoOrQuest;
        }
        
        private void SetInfoOrQuest(Quest quest)
        {
            _nameQuest.text = quest.Name;
            _currentProgressQuest.text = quest.CurrentProgress();
        }
    }
}