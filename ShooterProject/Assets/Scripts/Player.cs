using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
  // set in inspector
  public float speed = 0.1f;
  public GameObject bulletPrefab;
  public Transform bulletSpawnPoint;
  public Slider sliderHealth;
  public Shield shield;
  public float maxBulletCooldown;
  public GameObject expoPrefab;
  public UI ui;
    public AudioClip clipNormalFire;
    public AudioClip clipSuperFire;
    public AudioClip clipHurt;
    public AudioClip clipPowerup;

    // private fields
    private float health;
  private const float Y_LIMIT = 4.6f;
    private float BulletCooldown;
    private AudioSource audiosrc;

  private void Start() {
    health = 1.0f;
    BulletCooldown = maxBulletCooldown;
        audiosrc = GetComponent<AudioSource>();
  }

  private void Update() {
    sliderHealth.value = health;

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
            if (BulletCooldown >= maxBulletCooldown)
            {
                GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                bulletObj.GetComponent<Bullet>().speed *= 2;
                Instantiate(bulletPrefab, bulletSpawnPoint.position + Vector3.up * 0.5f, Quaternion.identity);
                Instantiate(bulletPrefab, bulletSpawnPoint.position + Vector3.up * -0.5f, Quaternion.identity);
                BulletCooldown = 0;
                audiosrc.clip = clipSuperFire;
                audiosrc.Play();
            }

        }
        else
        {
            BulletCooldown += Time.deltaTime;
            BulletCooldown = Mathf.Clamp(BulletCooldown, 0, maxBulletCooldown);
        }

        var vertMove = SpaceShooterInput.Instance.input.MoveVertically.ReadValue<float>();
    this.transform.Translate(Vector3.up * speed * Time.deltaTime * vertMove);

    if (this.transform.position.y > Y_LIMIT) {
      this.transform.position = new Vector3(transform.position.x, Y_LIMIT);
    }
    else if (this.transform.position.y < -Y_LIMIT) {
      this.transform.position = new Vector3(transform.position.x, -Y_LIMIT);
    }
  }

  public void DamageFromEnemy() {
    if (!shield.IsActive) {
      health -= 0.25f;
      audiosrc.clip = clipHurt;
      audiosrc.Play();
            if (health <= 0)
            {
                var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
                Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
                ui.ShowGameOver();

            }
    }
  }

  public void RefillShield() {
        audiosrc.clip = clipPowerup;
        audiosrc.Play();
        shield.FullRefill();
  }
}
