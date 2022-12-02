using System;
using Player;
using UnityEngine;

namespace QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        public static event Action<Quest> AddQuestToPlayer;
        public static event Action<Quest, Action> SetDescriprionQuest;
        [SerializeField] private Quest _quests;
        [SerializeField] private MeshRenderer _activeQuest;
        private bool isActiveQuest;

        private void AddQusetToPlayer()
        {
            AddQuestToPlayer?.Invoke(_quests);
            isActiveQuest = true;
            _activeQuest.material.color = Color.red;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerMovement>() && !isActiveQuest)
            {
                SetDescriprionQuest?.Invoke(_quests, AddQusetToPlayer);
            }
        }
    }
}