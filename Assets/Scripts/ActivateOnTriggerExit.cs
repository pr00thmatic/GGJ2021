using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTriggerExit : MonoBehaviour {
  public event System.Action onActivated;

  [Header("Configuration")]
  public string triggerName = "spread";

  [Header("Initialization")]
  public Collider sensorToExit;
  public Animator animator;
  public Movable movable;

  void OnTriggerExit (Collider c) {
    if (c == sensorToExit && (!movable || (movable && movable.DidExit))) {
      animator.SetTrigger(triggerName);
      onActivated?.Invoke();
    }
  }
}
