using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
    [SerializeField] private AsteroidController asteroidPrefab;
    [SerializeField] private SpaceJunkController spaceJunkPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private PlayerController player;
    [SerializeField] private int quantityObstacles;
    [SerializeField] private int delayTimeGenerate;
    void Start()
    {
        Invoke("GenerarObstaculos", delayTimeGenerate);
    }
    private void GenerarObstaculos()
    {
        int[] indexes = new int[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; ++i)
        {
            indexes[i] = i;
        }
        for (int i = 0; i < quantityObstacles; ++i)
        {
            float randomNumber = Random.Range(0, 10);
            int randomIndex = Random.Range(0, spawnPoints.Length - i);
            int spawnPointIndex = indexes[randomIndex];
            indexes[randomIndex] = indexes[spawnPoints.Length - i - 1];
            if (randomNumber < 5)
            {
                GameObject prefab = asteroidPrefab.gameObject;
                Transform spawnPoint = spawnPoints[spawnPointIndex];
                GameObject prefabInstantiate = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                AsteroidController asteroide = prefabInstantiate.GetComponent<AsteroidController>();
                asteroide.Player = player;
            }
            else
            {
                GameObject prefab = spaceJunkPrefab.gameObject;
                Transform spawnPoint = spawnPoints[spawnPointIndex];
                GameObject prefabInstantiate = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                SpaceJunkController garbage = prefabInstantiate.GetComponent<SpaceJunkController>();
                garbage.Player = player;
            }
        }
        Invoke("GenerarObstaculos", delayTimeGenerate);
    }
}