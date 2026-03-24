using UnityEngine;

public class Powerup : MonoBehaviour {
  // set in inspector
  public float speed;

  void Update() {
    transform.Translate(Vector3.left * speed * Time.deltaTime);
  }

  private void OnCollisionEnter2D(Collision2D c) {
  if (c.gameObject.CompareTag("Player")) {
      Destroy(gameObject);
      c.gameObject.GetComponent<Player>().RefillShield();
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
