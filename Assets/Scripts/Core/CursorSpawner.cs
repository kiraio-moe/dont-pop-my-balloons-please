using UnityEngine;

namespace Aili.Core
{
    [AddComponentMenu("Aili/Core/Cursor Spawner")]
    public class CursorSpawner : MonoBehaviour
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
            float randomX = Random.Range(pointA.position.x, pointB.position.x);
            float randomY = Random.Range(pointA.position.y, pointB.position.y);
            // float randomZ = Random.Range(pointA.position.z, pointB.position.z);
            Vector2 randomPosition = new Vector3(randomX, randomY);

            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }
}
