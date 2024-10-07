using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour
{
    public GameObject obstaclePrefab;
    float timeBetweenSpawns;
    public Vector2 minMaxTimeBetweenSpawns;
    float lastSpawnTime = 0f;
    float screenHalfWidthInWorldUnits;
    float screenHalfHeightInWorldUnits;
    public Vector2 obstacleSizeMinMax;
    public float spawnAngleMax;
    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.orthographicSize * Camera.main.aspect;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
    }

    void Update()
    {
        timeBetweenSpawns = Mathf.Lerp(minMaxTimeBetweenSpawns.x, minMaxTimeBetweenSpawns.y, Difficulty.GetDifficultyPercent());
        float obstacleSize = Random.Range(obstacleSizeMinMax.x, obstacleSizeMinMax.y);
        Vector2 spawnLocation = new Vector2(Random.Range(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits), screenHalfHeightInWorldUnits + obstacleSize/2);
        if (lastSpawnTime + timeBetweenSpawns < Time.time)
        {
          lastSpawnTime = Time.time;
          GameObject obstacle = Instantiate(obstaclePrefab, spawnLocation, Quaternion.Euler(Vector3.forward * Random.Range(-spawnAngleMax,spawnAngleMax)));
            obstacle.transform.localScale = new Vector3(obstacleSize,obstacleSize,0);
        }
    }
}
