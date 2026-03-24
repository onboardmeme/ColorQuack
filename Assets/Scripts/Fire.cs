using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Fire : MonoBehaviour
{
    public float speed = 95f;
    public GameObject FireEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FireEffect == null)
        {
            return;
        }

        this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        Destroy(gameObject, FireEffect.GetComponent<ParticleSystem>().main.duration);
    }
    }
