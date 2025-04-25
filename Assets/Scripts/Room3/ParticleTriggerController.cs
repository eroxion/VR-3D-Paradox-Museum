using UnityEngine;

namespace Room3
{  
    public class ParticleTriggerController : MonoBehaviour
    {
        public ParticleSystem particleSystem1;
        public ParticleSystem particleSystem2;
        public ParticleSystem particleSystem3;
        public ParticleSystem particleSystem4;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("RoomTrigger"))
            {
                particleSystem1.Play();
                particleSystem2.Play();
                particleSystem3.Play();
                particleSystem4.Play();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("RoomTrigger"))
            {
                particleSystem1.Stop();
                particleSystem2.Stop();
                particleSystem3.Stop();
                particleSystem4.Stop();
            }
        }
    }
}