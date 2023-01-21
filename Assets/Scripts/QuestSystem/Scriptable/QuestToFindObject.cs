using FindObjectQuest;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "QuestsFind", menuName = "Quests/QuestFind", order = 1)]
    public class QuestToFindObject : Quest
    {
        [SerializeField] private DefaultObjectFind _typePickUp;
        [SerializeField] private string _localizedName;
        [SerializeField] private int _countFind;
        [SerializeField] private int _currentFind = 0;

        private void OnEnable()
        {
            Reset();
        }

        public override void ChangeProgressQuest<TypePickUp>()
        {
            if (_typePickUp is TypePickUp)
            {
                _currentFind++;
            }
        }

        public override bool IsCompleteQuest()
        {
            return _currentFind == _countFind;
        }

        public override string CurrentProgress()
        {
            return IsCompleteQuest() 
                ? "Можете сдать квест!" 
                : $"Собрано {_localizedName} {_currentFind} из {_countFind}";
        }

        public override void Reset()
        {
            _currentFind = 0;
        }
    }
}