using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityCheck : MonoBehaviour {
  [Header("Information")]
  public int count = 0;
  public int Total { get => rays.childCount; }

  [Header("Initialization")]
  public Transform rays;
  public Transform visibilityTarget;

  void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      print(Check());
    }
  }

  public bool Check () {
    count = 0;
    RaycastHit hit;
    foreach (Transform child in rays) {
      Ray ray = new Ray(child.position, visibilityTarget.position - child.position);
      if (!Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Clickable"))) {
        count++;
      }
    }

    return count == Total;
  }
}
