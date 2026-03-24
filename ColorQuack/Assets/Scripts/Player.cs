using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class Player : MonoBehaviour {
  // set in inspector
  public float speed = 0.1f;
  public GameObject bulletPrefab;
  public Transform bulletSpawnPoint;
  public Slider sliderHealth;
  public Shield shield;
  public float maxBulletCooldown;
  public float maxSuperCooldown;
  public float maxSuperMeter;
  public GameObject expoPrefab;
  public UI ui;
  public GameObject SuperBulletPrefab;
  public AudioClip clipNormalFire;
  public AudioClip clipSuperFire;
  public AudioClip clipHurt;
  public AudioClip clipPowerup;
  public Slider sliderSuper;

    // private fields
    private float health;
  private const float Y_LIMIT = 4.6f;
    private const float X_LIMIT = 8.3f;
    private float BulletCooldown;
    private float SuperCooldown;
    private float SuperMeter;
    private AudioSource audiosrc;

  private void Start() {
    health = 1.0f;
        SuperMeter = 0f;
        BulletCooldown = maxBulletCooldown;
    SuperCooldown = maxSuperCooldown;
        audiosrc = GetComponent<AudioSource>();
  }

  private void Update() {
    sliderHealth.value = health;
    sliderSuper.value = Mathf.Clamp(SuperMeter / maxSuperMeter, 0f, 1f);

        if (SpaceShooterInput.Instance.input.Fire.WasPressedThisFrame()) {
            if (BulletCooldown >= maxBulletCooldown)
            {
                GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                BulletCooldown = 0;
                audiosrc.clip = clipNormalFire;
                audiosrc.Play();
            }
            
    }
    else
        {
            BulletCooldown += Time.deltaTime;
            BulletCooldown = Mathf.Clamp(BulletCooldown, 0, maxBulletCooldown);
        }
        if (SpaceShooterInput.Instance.input.SuperFire.WasPressedThisFrame())
        {
            if (SuperCooldown >= maxSuperCooldown)
            {
                if (SuperMeter > 0)
                {
                    GameObject SuperObj = Instantiate(SuperBulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                    SuperObj.GetComponent<Fire>().speed *= 2;
                    SuperCooldown = 0;
                    audiosrc.clip = clipSuperFire;
                    audiosrc.Play();
                    SuperMeter -= maxSuperMeter * 0.25f;
                }
            }

        }
        else
        {
            SuperCooldown += Time.deltaTime;
            SuperCooldown = Mathf.Clamp(SuperCooldown, 0, maxSuperCooldown);
        }

        var vertMove = SpaceShooterInput.Instance.input.MoveVertically.ReadValue<float>();
    this.transform.Translate(Vector3.up * speed * Time.deltaTime * vertMove);
        var horzMove = SpaceShooterInput.Instance.input.MoveHorizontally.ReadValue<float>();
        this.transform.Translate(Vector3.right * speed * Time.deltaTime * horzMove);

    if (this.transform.position.y > Y_LIMIT) {
      this.transform.position = new Vector3(transform.position.x, Y_LIMIT);
    }
    else if (this.transform.position.y < -Y_LIMIT) {
      this.transform.position = new Vector3(transform.position.x, -Y_LIMIT);
    }
        if (this.transform.position.x > X_LIMIT)
        {
            this.transform.position = new Vector3(X_LIMIT, transform.position.y);
        }
        else if (this.transform.position.x < -X_LIMIT)
        {
            this.transform.position = new Vector3(-X_LIMIT, transform.position.y);
        }
    }


    public void DamageFromEnemy() {
        if (!shield.IsActive)
        {
            health -= 0.25f;
            audiosrc.clip = clipHurt;
            audiosrc.Play();
            if (health <= 0)
            {
                var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
                Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
                Destroy(gameObject);
                ui.ShowGameOver();

            }
        }
  }
    public void DamageFromEnemyAlt()
    {
        if (shield.IsActive)
        {
            health -= 0.25f;
            audiosrc.clip = clipHurt;
            audiosrc.Play();
            if (health <= 0)
            {
                var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
                Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
                Destroy(gameObject);
                ui.ShowGameOver();

            }
        }
    }

    public void RefillShield()
    {
        audiosrc.clip = clipPowerup;
        audiosrc.Play();
        SuperMeter = maxSuperMeter;
    }
}
