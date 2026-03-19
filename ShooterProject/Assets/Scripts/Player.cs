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

  // private fields
  private float health;
  private const float Y_LIMIT = 4.6f;
    private float BulletCooldown;

  private void Start() {
    health = 1.0f;
    BulletCooldown = maxBulletCooldown;
  }

  private void Update() {
    sliderHealth.value = health;

    if (SpaceShooterInput.Instance.input.Fire.WasPressedThisFrame()) {
            if (BulletCooldown >= maxBulletCooldown)
            {
                GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                BulletCooldown = 0;
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
    }
  }

  public void RefillShield() {
    shield.FullRefill();
  }
}
