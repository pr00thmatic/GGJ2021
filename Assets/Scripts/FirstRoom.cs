using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour {
  [Header("Initialization")]
  public VisibilityCheck key;
  public CameraSolutionChecker solution;
  public Light theLight;
  public float lightSmoothTime = 0.2f;

  [Header("Information")]
  public float lightSmoothSpeed = 0;
  public float bounceSmoothSpeed = 0;
  public int lightCount = 0;

  void OnEnable () {
    Movable.onDeselected += HandleBox;
    UpdateLight();
  }

  void OnDisable () {
    Movable.onDeselected -= HandleBox;
  }

  void Update () {
    UpdateLight();
  }

  public void HandleBox (Movable box) {
    if (!box.GetComponentInParent<FirstRoom>()) return;
    solution.canBeSolved = key.Check();
    if (key.count > lightCount) {
      lightCount = key.count;
      RewardSound.Instance.Play();
    }
    UpdateLight();
  }

  public void UpdateLight () {
    key.Check();
    float t = key.count / (float) key.Total;
    theLight.intensity = Mathf.SmoothDamp(theLight.intensity, Mathf.Lerp(0.02f, 0.2f, t),
                                          ref lightSmoothSpeed, lightSmoothTime);
    theLight.bounceIntensity = Mathf.SmoothDamp(theLight.bounceIntensity, Mathf.Lerp(0, 2, t),
                                                ref bounceSmoothSpeed, lightSmoothTime);
  }
}
