using UnityEngine;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shield : MonoBehaviour {
  // set in inspector
  public GameObject shield;

  // private

  public bool IsActive { get; private set; }

  void Start() {
    shield.SetActive(false);
  }

  void Update() {
    if (shield == null) {
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