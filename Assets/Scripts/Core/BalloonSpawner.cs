using UnityEngine;

namespace Aili.Core
{
    [AddComponentMenu("Aili/Core/Balloon Spawner")]
    public class BalloonSpawner : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public Transform pointA;
        public Transform pointB;

        [SerializeField]
        [Range(0.01f, 1)]
        float m_SpawnDelay = 0.1f;

        float spawnTime;

        void Update()
        {
            spawnTime += Time.deltaTime;

            if (spawnTime >= m_SpawnDelay)
            {
                spawnTime = 0;
                SpawnObject();
            }
        }

        void SpawnObject()
        {
            // Calculate a random position between pointA and pointB
            float randomX = Random.Range(pointA.position.x, pointB.position.x);
            float randomY = Random.Range(pointA.position.y, pointB.position.y);
            float randomZ = Random.Range(pointA.position.z, pointB.position.z);

            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

            // Instantiate the object at the random position
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }
}
