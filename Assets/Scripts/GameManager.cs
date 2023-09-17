using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Transform> waypoints;

    public Transform spawnPoint;

    public GameObject[] enemyPrefabs;

    public List<Enemy> enemies;

    private float delay = 1f;

    public int maxZombie = 5;

    public GameObject vfxSpawn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (enemies.Count < maxZombie)
        {
            if (delay <= 0)
            {
                delay = 1f;
                GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoint.position, Quaternion.identity);
                GameObject vfx = Instantiate(vfxSpawn, spawnPoint.position, Quaternion.identity);
                Destroy(vfx, 1f);
                enemies.Add(enemy.GetComponent<Enemy>());
            }
            else
            {
                delay -= Time.deltaTime;
            }

        }
    }
}