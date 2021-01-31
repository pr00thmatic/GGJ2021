using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRoomVictoryCondition : MonoBehaviour {
  [Header("Information")]
  public bool fishingRods = false;
  public bool boat = false;
  public bool bait = false;

  [Header("Initialization")]
  public ActivateOnTriggerExit rod;
  public BaitBox baitBox;
  public VisibilityCheck boatVisibility;
  public VisibilityCheck boatAlternativeVisibility;
  public CameraSolutionChecker solutionChecker;
  public Transform lights;
  public Light centerLight;

  void OnEnable () {
    rod.onActivated += HandleActivation;
    baitBox.onSolved += HandleSolve;
    Movable.onDeselected += HandleBoat;
  }

  void OnDisable () {
    Movable.onDeselected -= HandleBoat;
  }

  void Update () {
    boatAlternativeVisibility.Check();
    float t = boatAlternativeVisibility.count / (float) boatAlternativeVisibility.Total;
    centerLight.bounceIntensity = Mathf.Lerp(0, 30, t);
    centerLight.intensity = Mathf.Lerp(0, 0.05f, t);
  }

  public void HandleBoat (Movable m) {
    if (m.GetComponentInParent<SecondRoom>()) {
      boat = boatVisibility.Check();
    }
    CheckSolvable();
  }

  public void HandleActivation () {
    fishingRods = true;
    CheckSolvable();
  }

  public void HandleSolve () {
    bait = true;
    CheckSolvable();
  }

  public void CheckSolvable () {
    if (fishingRods && boat && bait) {
      solutionChecker.canBeSolved = true;
      lights.GetChild(2).gameObject.SetActive(true);
    } else {
      solutionChecker.canBeSolved = false;
      lights.GetChild(2).gameObject.SetActive(false);
    }
  }
}
