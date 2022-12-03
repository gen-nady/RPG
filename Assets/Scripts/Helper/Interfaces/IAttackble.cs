using UnityEngine;

namespace Helper
{
    public interface IAttackble
    {
        void Attack(Collider other);
    }
}