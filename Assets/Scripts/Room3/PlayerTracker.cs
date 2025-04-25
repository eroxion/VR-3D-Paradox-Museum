using Unity.XR.CoreUtils;
using UnityEngine;

namespace Room3
{
    public class PlayerTracker : MonoBehaviour
    {
        public XROrigin xrOrigin;
        public Transform trackedPlayer;

        void Update()
        {
            trackedPlayer.position = xrOrigin.Camera.transform.position;
        }
    }
}
