using QuestSystem;
using UnityEngine;
using Zenject;

namespace FindObjectQuest
{
   
    public abstract class DefaultObjectFind : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigibody;
        [Inject] protected PlayerQuest _playerQuest;
    }
}