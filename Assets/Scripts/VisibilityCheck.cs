using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityCheck : MonoBehaviour {
  [Header("Initialization")]
  public Transform rays;
  public Transform visibilityTarget;

  // void Update () {
  //   if (Input.GetKeyDown(KeyCode.Space)) {
  //     print(Check());
  //   }
  // }

  public bool Check () {
    RaycastHit hit;
    foreach (Transform child in rays) {
      Ray ray = new Ray(child.position, visibilityTarget.position - child.position);
      if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Clickable"))) {
        // Debug.Log(hit.collider, hit.collider);
        return false;
      }
    }

    return true;
  }
}
