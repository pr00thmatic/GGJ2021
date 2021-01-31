using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnDisable : MonoBehaviour {
  [Header("Initialization")]
  public GameObject target;

  void OnDisable () {
    target.SetActive(true);
  }
}
