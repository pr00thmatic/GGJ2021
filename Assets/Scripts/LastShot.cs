using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastShot : MonoBehaviour {
  public Transform solvedGuyTarget;

  void OnEnable () {
    Guy.Instance.Go(solvedGuyTarget);
  }
}
