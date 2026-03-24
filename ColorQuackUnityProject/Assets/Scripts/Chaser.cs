using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Transform = UnityEngine.Transform;

public class Chaser : MonoBehaviour {
  // set in inspector
  public float speed;
  public GameObject expoPrefab;
    public float bulletDamage;
    public Transform playertrack;

    private float health;

    private void Start()
    {
        health = 1f;
    }

    void Update() {
        Vector3 player = new Vector3(playertrack.position.x, playertrack.position.y, 0);
    transform.Translate(Vector3.left * speed * Time.deltaTime);
        Vector3.Lerp(Vector3.up, player, speed * Time.deltaTime);
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
            var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
            Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
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
