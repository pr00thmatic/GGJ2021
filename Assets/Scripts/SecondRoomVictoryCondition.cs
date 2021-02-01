using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRoomVictoryCondition : MonoBehaviour {
  [Header("Information")]
  public bool fishingRods = false;
  public bool boat = false;
  public bool bait = false;
  public int lightLevel = 0;

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
    if (lightLevel < boatVisibility.count) {
      RewardSound.Instance.Play();
      lightLevel = boatVisibility.count;
    }
    CheckSolvable();
  }

  public void HandleActivation () {
    RewardSound.Instance.Play();
    fishingRods = true;
    CheckSolvable();
  }

  public void HandleSolve () {
    RewardSound.Instance.Play();
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
