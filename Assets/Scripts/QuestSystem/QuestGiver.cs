using System;
using DG.Tweening;
using Helper;
using NPC;
using Player;
using UnityEngine;
using Zenject;

namespace QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        public static event Action<Quest> AddQuestToPlayer;
        [SerializeField] private Quest _quests;
        [SerializeField] private MeshRenderer _activeQuest;
        [Inject] private QuestGiverUI _questGiverUI;
        private bool isActiveQuest;

        private void Start()
        {
            DOTween.Sequence()
                .Append(_activeQuest.transform.DOScale(new Vector3(1f, 1f, 1f), 2f))
                .Append(_activeQuest.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f) , 2f))
                .SetLoops(-1);
        }
        
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
                _questGiverUI.SetQuestText(_quests, AddQusetToPlayer);
            }
        }
    }
}