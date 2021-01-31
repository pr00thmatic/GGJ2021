using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSolutionChecker : MonoBehaviour {
  public event System.Action onRoomSolved;
  public bool canBeSolved = false;

  void OnTriggerStay (Collider c) {
    if (!canBeSolved) return;

    if (c.GetComponent<CameraSolution>()) {
      onRoomSolved?.Invoke();
    }
  }
}
