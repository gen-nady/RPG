using System;
using Helper;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private IAttackble _attack;

        private void Awake()
        {
            _attack = new TouchAttack();
        }

        private void OnTriggerEnter(Collider other)
        {
            _attack.Attack(other);
        }
    }
}