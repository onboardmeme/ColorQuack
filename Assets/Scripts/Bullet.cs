using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 95f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
            if (collision.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }
}
