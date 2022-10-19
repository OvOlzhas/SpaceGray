using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float complicationCoeff = 0.8f;
    private float nextSpawn = 0.0f;
    [SerializeField] private float levelUpRate = 60f;
    [SerializeField] private float levelUpTime = 60f;
    [SerializeField] private GameObject levelUpText;

    private void Start()
    {
        levelUpTime = Time.time + levelUpRate;
    }

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Spawn();
        }

        if (Time.time >= levelUpTime)
        {
            LevelUp();
        }
    }

    Vector3 RandomPointInBox()
    {
        Bounds bounds = coll.bounds;
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
            );
    }
    
    void Spawn()
    {
        Instantiate(enemyPrefab, RandomPointInBox(), coll.transform.rotation);
    }

    public void LevelUp()
    {
        nextSpawn = Time.time + 4f + spawnRate;
        levelUpTime += levelUpRate;
        Instantiate(levelUpText, transform.position, Quaternion.identity);
        spawnRate *= complicationCoeff;
    }
}
