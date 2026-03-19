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
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }
}
