using Enemy;
using UnityEngine;

namespace Helper
{
    public class TouchAttack : IAttackble
    {
        public void Attack(Collider other)
        {
            if (other.GetComponent<MainEnemy>())
            {
                
            }
        }
    }
}