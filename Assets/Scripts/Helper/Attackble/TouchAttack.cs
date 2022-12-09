using Cinemachine;
using Enemy;
using Player;
using UnityEngine;

namespace Helper
{
    public class TouchAttack : IAttackble
    {
        public void Attack(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                
            }
        }
    }
}