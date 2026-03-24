using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour {
  // set in inspector
  public float enemySpawnDelay;
  public GameObject enemyPrefab;
  public GameObject enemy2Prefab;
  public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    public GameObject bossPrefab;
    public GameObject powerupPrefab;
  public BoxCollider2D spawnRange;
  public UI ui;
    public float bossSpawnDelay;

  // private fields
  private float powerUpDelay;
  private float enemySpawnTimer;
  private float powerupSpawnTimer;
    private float bossSpawnTimer;

  private void Start() {
    powerUpDelay = Random.Range(5f, 10f);
    powerupSpawnTimer = 0;
  }

  private void SpawnEnemy() {
    Vector3 enemySpawnPt = new Vector3(
        Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
        Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
        0);
    Instantiate(enemyPrefab, enemySpawnPt, Quaternion.identity);
  }
   private void SpawnEnemy2(){
        Vector3 enemySpawnPt = new Vector3(
            Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
            Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
            0);
        Instantiate(enemy2Prefab, enemySpawnPt, Quaternion.identity);
   }
    private void SpawnEnemy3()
    {
        Vector3 enemySpawnPt = new Vector3(
            Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
            Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
            0);
        Instantiate(enemy3Prefab, enemySpawnPt, Quaternion.identity);
    }
    private void SpawnEnemy4()
    {
        Vector3 enemySpawnPt = new Vector3(
            Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
            Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
            0);
        Instantiate(enemy4Prefab, enemySpawnPt, Quaternion.identity);
    }
    private void SpawnPowerup() {
    Vector3 powerupSpawnPt = new Vector3(
        Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
        Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
        0);
    Instantiate(powerupPrefab, powerupSpawnPt, Quaternion.identity);
  }
    private void SpawnBoss()
    {
        Vector3 bossSpawnPt = new Vector3(
            Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x), 0, 0
            );
        Instantiate(bossPrefab, bossSpawnPt, Quaternion.identity);
    }
  void Update() {
    // check spawn enemy
    // if (!ui.IsReady) return;

    if (!ui.IsReady)
        {
            return;
        }

    enemySpawnTimer += Time.deltaTime;
    if (enemySpawnTimer >= enemySpawnDelay) {
      SpawnEnemy();
      enemySpawnTimer = 0.0f;
    }

    enemySpawnTimer += Time.deltaTime;
    if (enemySpawnTimer >= enemySpawnDelay) {
      SpawnEnemy2();
      enemySpawnTimer = 0.0f;
    }

    enemySpawnTimer += Time.deltaTime;
    if (enemySpawnTimer >= enemySpawnDelay) {
      SpawnEnemy3();
      enemySpawnTimer = 0.0f;
    }

        enemySpawnTimer += Time.deltaTime;
        if (enemySpawnTimer >= enemySpawnDelay)
        {
            SpawnEnemy4();
            enemySpawnTimer = 0.0f;
        }

        bossSpawnTimer += Time.deltaTime;
        if (bossSpawnTimer >= bossSpawnDelay)
        {
            SpawnBoss();
            bossSpawnTimer = 0.0f;
        }

        // check spawn powerup
        powerupSpawnTimer += Time.deltaTime;
    if (powerupSpawnTimer >= powerUpDelay) {
      SpawnPowerup();
      powerUpDelay = Random.Range(5, 10);
      powerupSpawnTimer = 0.0f;
    }
  }
}
