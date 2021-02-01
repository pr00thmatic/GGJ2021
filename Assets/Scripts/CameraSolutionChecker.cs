using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSolutionChecker : MonoBehaviour {
  public event System.Action<CameraSolution> onRoomSolved;
  public bool canBeSolved = false;
  public List<CameraSolution> solved;

  void OnTriggerStay (Collider c) {
    if (!canBeSolved) return;

    CameraSolution justSolved = c.GetComponent<CameraSolution>();
    if (justSolved && !solved.Contains(justSolved)) {
      solved.Add(justSolved);
      onRoomSolved?.Invoke(justSolved);
      RewardSound.Instance.Play();
    }
  }
}
