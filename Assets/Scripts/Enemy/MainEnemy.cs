using QuestSystem;
using UnityEngine;

namespace Enemy
{
    public abstract class MainEnemy : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigibody;
        [SerializeField] protected PlayerQuest _playerQuest;
    }
}