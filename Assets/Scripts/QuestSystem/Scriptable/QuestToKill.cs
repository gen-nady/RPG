using System;
using Enemy;
using NPC;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "Quests", menuName = "Quests/Quest", order = 0)]
    public class QuestToKill : Quest
    {
        [SerializeField] private MainEnemy _typeKill;
        [SerializeField] private int _countToKill;
        [SerializeField] private int _currentToKill = 0;

        public override bool ProgressQuest<TypeKill>()
        {
            if (_typeKill is TypeKill)
            {
                _currentToKill++;
            }
            return _countToKill == _currentToKill;
        }
        
        public override string CurrentProgress()
        {
            return $"Убито {nameof(MainEnemy)} {_currentToKill} из {_countToKill}";
        }

        public override void Reset()
        {
            _countToKill = 0;
        }
    }
}