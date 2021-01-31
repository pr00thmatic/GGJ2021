using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour {
  [Header("Initialization")]
  public VisibilityCheck key;
  public CameraSolutionChecker solution;
  public Light theLight;

  void OnEnable () {
    Movable.onDeselected += HandleBox;
    // solution.onRoomSolved += HandleRoomSolved;
    UpdateLight();
  }

  void OnDisable () {
    Movable.onDeselected -= HandleBox;
    // solution.onRoomSolved -= HandleRoomSolved;
  }

  public void HandleBox (Movable box) {
    if (!box.GetComponentInParent<FirstRoom>()) return;
    solution.canBeSolved = key.Check();
    UpdateLight();
  }

  public void UpdateLight () {
    float t = key.count / (float) key.Total;
    theLight.intensity = Mathf.Lerp(0.02f, 0.2f, t);
    theLight.bounceIntensity = Mathf.Lerp(0, 2, t);
  }
}
