using UnityEngine;

public class BigEnemyB : MonoBehaviour {
  // set in inspector
  public float speed;
  public GameObject expoPrefab;
    public GameObject enemyspawn;

  void Update() {
    transform.Translate(Vector3.left * speed * Time.deltaTime);
  }

  private void OnCollisionEnter2D(Collision2D c) {
    if (c.gameObject.CompareTag("Bullet")) {
      var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
      Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
      Destroy(gameObject);
      Instantiate(enemyspawn, transform.position + Vector3.up * 0.5f, Quaternion.identity);
      Instantiate(enemyspawn, transform.position + Vector3.up * -0.5f, Quaternion.identity);
      Score.Instance.HitEnemy();
    }
    else if (c.gameObject.CompareTag("Player")) {
            var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
            Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
      c.gameObject.GetComponent<Player>().DamageFromEnemy();
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
