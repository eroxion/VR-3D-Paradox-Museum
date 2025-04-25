using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Room2
{
    public class CubeRoomManager : MonoBehaviour
    {
        [Header("Cube Settings")]
        [SerializeField] private List<GameObject> cubePrefabs;
        [SerializeField] private int maxCubes = 100;
        [SerializeField] private float baseCubeSpeed = 5f;
        [SerializeField] private float playerInfluenceFactor = 2f;
        [SerializeField] private Vector2 spinSpeedRange = new Vector2(10, 30);

        [Header("Spawn Area")]
        [SerializeField] private BoxCollider roomTrigger;

        private Transform player;
        private Vector3 previousPlayerPosition;
        private List<GameObject> activeCubes = new List<GameObject>();

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            previousPlayerPosition = player.position;
            StartCoroutine(ManageCubes());
        }

        private IEnumerator ManageCubes()
        {
            SpawnCubes(maxCubes);

            while (true)
            {
                Vector3 playerVelocity = (player.position - previousPlayerPosition) / Time.deltaTime;
                previousPlayerPosition = player.position;

                List<GameObject> cubesToProcess = new List<GameObject>(activeCubes);
                foreach (GameObject cube in cubesToProcess)
                {
                    if (cube == null) continue;

                    // Base movement + player influence
                    float effectiveSpeed = baseCubeSpeed + (playerVelocity.z * playerInfluenceFactor);
                    cube.transform.Translate(
                        0,
                        0,
                        -effectiveSpeed * Time.deltaTime,
                        Space.World
                    );

                    if (!roomTrigger.bounds.Contains(cube.transform.position))
                    {
                        RemoveCube(cube);
                        SpawnCubes(1);
                    }
                }

                yield return null;
            }
        }

        private void SpawnCubes(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Vector3 spawnPos = new Vector3(
                    Random.Range(roomTrigger.bounds.min.x, roomTrigger.bounds.max.x),
                    Random.Range(roomTrigger.bounds.min.y, roomTrigger.bounds.max.y),
                    Random.Range(roomTrigger.bounds.min.z, roomTrigger.bounds.max.z)
                );

                GameObject prefab = cubePrefabs[Random.Range(0, cubePrefabs.Count)];
                Quaternion randomRot = Random.rotation;

                GameObject cube = Instantiate(prefab, spawnPos, randomRot, transform);

                CubeRotator rotator = cube.AddComponent<CubeRotator>();
                rotator.rotationSpeed = new Vector3(
                    Random.Range(spinSpeedRange.x, spinSpeedRange.y),
                    Random.Range(spinSpeedRange.x, spinSpeedRange.y),
                    Random.Range(spinSpeedRange.x, spinSpeedRange.y)
                );

                activeCubes.Add(cube);
            }
        }

        public void RemoveCube(GameObject cube)
        {
            if (activeCubes.Contains(cube))
            {
                activeCubes.Remove(cube);
                Destroy(cube);
            }
        }

        private void OnDestroy()
        {
            foreach (GameObject cube in activeCubes)
            {
                if (cube != null) Destroy(cube);
            }
            activeCubes.Clear();
        }
    }
}