using Player;
using UnityEngine;

namespace QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        [SerializeField] private Quest _quests;
        [SerializeField] private GameObject _activeQuest;
        private bool isActiveQuest;
        private PlayerQuest _playerQuest;
        private QuestGiverUI _questGiverUI;
        private void Start()
        {
            Constructor();
        }

        private void Constructor()
        {
            _playerQuest = PlayerQuest.Instance;
            _questGiverUI = QuestGiverUI.Instance;
        }

        private void AddQusetToPlayer()
        {
            _playerQuest.SetQuest(_quests);
            isActiveQuest = true;
            _activeQuest.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerMovement>() && !isActiveQuest)
            {
                _questGiverUI.SetQuestText(_quests, AddQusetToPlayer);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
            }
        }
    }
}