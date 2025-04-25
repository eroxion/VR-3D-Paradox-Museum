using UnityEngine;

namespace Room3
{
    public class BlueLineController : MonoBehaviour
    {
        public Transform player;
        public float orbitRadius = 2f;
        public float orbitSpeed = 90f;
        public float verticalFallSpeed = 8f;
        public float positionLerpSpeed = 3f;

        private ParticleSystem particles;
        private ParticleSystem.Particle[] particleArray;
        private float[] particleAngles;
        private Vector3[] initialDirections;

        void Start()
        {
            particles = GetComponent<ParticleSystem>();
            particleArray = new ParticleSystem.Particle[particles.main.maxParticles];
            particleAngles = new float[particles.main.maxParticles];
            initialDirections = new Vector3[particles.main.maxParticles];
        }

        void Update()
        {
            int numParticles = particles.GetParticles(particleArray);
            Vector3 playerGroundPos = new Vector3(player.position.x, 0, player.position.z);

            for (int i = 0; i < numParticles; i++)
            {
                if (particleArray[i].remainingLifetime >= particleArray[i].startLifetime * 0.95f)
                {
                    particleAngles[i] = Random.Range(0f, 360f);
                    initialDirections[i] = new Vector3(
                        Random.Range(-1f, 1f),
                        0,
                        Random.Range(-1f, 1f)
                    ).normalized;
                }

                if (particleArray[i].position.y > 0.1f)
                {
                    particleArray[i].velocity = Vector3.down * verticalFallSpeed;
                }
                else
                {
                    particleAngles[i] += orbitSpeed * Time.deltaTime;
                    Vector3 targetOffset = Quaternion.Euler(0, particleAngles[i], 0) * 
                                         (initialDirections[i] * orbitRadius);
                    
                    particleArray[i].position = Vector3.Lerp(
                        particleArray[i].position,
                        playerGroundPos + targetOffset,
                        positionLerpSpeed * Time.deltaTime
                    );
                }
            }
            particles.SetParticles(particleArray, numParticles);
        }
    }
}