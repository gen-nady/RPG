using TMPro;
using UnityEngine;

namespace QuestSystem
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameQuest;
        private QuestInfo _quest;

        public void FillQuest(QuestInfo quest)
        {
            _quest = quest;
            _nameQuest.text = _quest.Name;
        }
    }
}