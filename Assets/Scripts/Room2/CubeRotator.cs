using UnityEngine;

namespace Room2
{
    public class CubeRotator : MonoBehaviour
    {
        internal Vector3 rotationSpeed;
        
        private void Update()
        {
            transform.Rotate(
                rotationSpeed * Time.deltaTime,
                Space.Self
            );
        }
    }
}