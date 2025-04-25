using UnityEngine;

namespace Room2
{
    public class CubeLifetime : MonoBehaviour
    {
        private CubeRoomManager roomManager;

        private void Start()
        {
            roomManager = GetComponentInParent<CubeRoomManager>();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("RoomTrigger"))
            {
                roomManager.RemoveCube(gameObject);
            }
        }
    }
}