using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Shield : MonoBehaviour {
  // set in inspector
  //public float maxProtectionTime;
  public GameObject shield;

  // private
  //private Slider slider;
  //private float protectionTime;

  public bool IsActive { get; private set; }

  void Start() {
    //slider = GetComponent<Slider>();
    //slider.value = 1.0f;
    //protectionTime = maxProtectionTime;
    shield.SetActive(false);
  }

  void Update() {
        if (shield == null)
        {
            return;
        }
    if (SpaceShooterInput.Instance.input.Shield.IsPressed()) {
        IsActive = true;
      }
    else {
      IsActive = false;
    }
    shield.SetActive(IsActive);
  }

}
