using FindObjectQuest;
using UnityEngine;

namespace Player
{
    public class PlayerPickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BallObject>())
            {
                other.GetComponent<BallObject>().PickUp();
            }
        }
    }
}