using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnEnable : MonoBehaviour {
  public GameObject toDisable;

  void OnEnable () {
    toDisable.SetActive(false);
  }
}
