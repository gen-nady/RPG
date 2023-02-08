using System;
using System.Collections.Generic;
using DG.Tweening;
using Helper;
using NPC;
using Player;
using UnityEngine;
using Zenject;

namespace QuestSystem
{
    public class QuestGiver : NPC.NPC
    {
        public static event Action<Quest> AddQuestToPlayer;
        public static event Action<Quest> QuestCompleted;
        [SerializeField] private List<Quest> _quests;
        [SerializeField] private MeshRenderer _activeQuest;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _speed;
        [SerializeField] private float _defaultTimeRotate;
        private Animator _animator;
        private Rigidbody _rigibody;
        private Sequence _questAnim;
        private float _timeToRotate;
        private bool _isActiveQuest;
        private bool _isAllQuest;
        [Inject] private QuestGiverUI _questGiverUI;
        [Inject] private PlayerQuest _playerQuest;
        private readonly int _walk = Animator.StringToHash("Walk");
        private void Awake()
        {
            _timeToRotate = _defaultTimeRotate;
            _rigibody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            InitNPC();
            _questAnim = DOTween.Sequence()
                .Append(_activeQuest.transform.DOScale(new Vector3(1f, 1f, 1f), 2f))
                .Append(_activeQuest.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f) , 2f))
                .SetLoops(-1);
        }
        protected override void InitNPC()
        {
            _movable = new StayNPC();
        }

        private void FixedUpdate()
        {
            if (_movable is not FreeMoveNPC) return;
            _timeToRotate -= Time.deltaTime;
            if (_timeToRotate <= 0)
            {
                SwitchDirection();
            }
            Move(_direction);
        }

        private void SwitchDirection()
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            _direction *= -1;
            _timeToRotate = _defaultTimeRotate;
        }

        private void AddQusetToPlayer()
        {
            AddQuestToPlayer?.Invoke(_quests[0]);
            _isActiveQuest = true;
            _activeQuest.material.color = Color.red;
        }
        
        private void GetBonusesForQuest()
        {
            QuestCompleted?.Invoke(_quests[0]);
            _quests.RemoveAt(0);
            if (_quests.Count > 0)
            {
                _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                _activeQuest.material.color = Color.white;
                _isActiveQuest = false;
                return;
            }
            _questAnim.Kill();
            _activeQuest.gameObject.SetActive(false);
            _isAllQuest = true;
            _movable = new FreeMoveNPC(_rigibody,_speed);
            _animator.SetTrigger(_walk);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(_isAllQuest) return;
            if (other.GetComponent<PlayerMovement>())
            {
                if (_isActiveQuest)
                {
                    var quest = _playerQuest.CurrentQuestPlayer;
                    if (_quests[0].Equals(quest))
                    {
                        if (quest.IsCompleteQuest())
                        {
                            _questGiverUI.CompletedQuest(quest,GetBonusesForQuest);
                        }
                    }
                }
                else
                {
                    _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                }
            }
        }
    }
}