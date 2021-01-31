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
  public CameraSolutionChecker solutionChecker;

  void OnEnable () {
    rod.onActivated += HandleActivation;
    baitBox.onSolved += HandleSolve;
    Movable.onDeselected += HandleBoat;
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
    } else {
      solutionChecker.canBeSolved = false;
    }
  }
}
