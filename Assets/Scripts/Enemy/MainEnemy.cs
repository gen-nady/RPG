using QuestSystem;
using UnityEngine;
using Zenject;

namespace Enemy
{

    public abstract class MainEnemy : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigibody;
        [Inject] protected PlayerQuest _playerQuest;
    }
}