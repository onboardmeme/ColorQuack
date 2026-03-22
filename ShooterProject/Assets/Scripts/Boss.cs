using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Boss : MonoBehaviour {
  // set in inspector
  public float speed;
    public GameObject expoPrefab;
    public float minionSpawnDelay;
    public GameObject enemy1prefab;
    public GameObject enemy2prefab;
    public float bulletDamage;
    public Transform minionSpawnPoint;

    private float health;
    private float minionSpawnTimer;

    private void Start()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        health = 1f;
        minionSpawnTimer = 0f;
    }

    private void SpawnEnemy()
    {
        GameObject minion = Instantiate(enemy1prefab, minionSpawnPoint.position, Quaternion.identity);
    }

    private void SpawnEnemy2()
    {
        GameObject minion = Instantiate(enemy2prefab, minionSpawnPoint.position, Quaternion.identity);
    }

    void Update() {
        minionSpawnTimer += Time.deltaTime;
        if (minionSpawnTimer >= minionSpawnDelay)
        {
            SpawnEnemy();
            minionSpawnTimer = 0.0f;
        }
        minionSpawnTimer += Time.deltaTime;
        if (minionSpawnTimer >= minionSpawnDelay)
        {
            SpawnEnemy2();
            minionSpawnTimer = 0.0f;
        }
    }

  private void OnCollisionEnter2D(Collision2D c) {

        if (c.gameObject.CompareTag("Bullet"))
        {
            health -= bulletDamage;
            if (health <= 0)
            {
                var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
                Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
                Destroy(gameObject);
                Score.Instance.HitEnemy();
            }
        }
        else if (c.gameObject.CompareTag("Player"))
        {
            c.gameObject.transform.Translate(Vector3.right * -speed * Time.deltaTime);
            c.gameObject.GetComponent<Player>().DamageFromEnemy();
            c.gameObject.GetComponent<Player>().DamageFromEnemyAlt();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }
}
