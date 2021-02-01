using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
  public GameObject box;
  public GameObject eye;

  void OnEnable () {
    Movable.onDeselected += EyeTutorial;
  }

  public void EyeTutorial (Movable movable) {
    eye.SetActive(true);
    box.SetActive(false);
    Movable.onDeselected -= EyeTutorial;
  }

  void Update () {
    if (eye.activeSelf) {
      if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {
        eye.SetActive(false);
      }
    }
  }
}
