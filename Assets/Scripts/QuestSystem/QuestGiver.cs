using Player;
using UnityEngine;

namespace QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        [SerializeField] private GameObject _activeQuest;
        
        private PlayerQuest _playerQuest;
        private void Start()
        {
            Constructor();
            CheckForActiveQuest();
        }

        private void Constructor()
        {
            _playerQuest = PlayerQuest.Instance;
        }

        private void CheckForActiveQuest()
        {
          
        }

        private void AddQuestToPlayer()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
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