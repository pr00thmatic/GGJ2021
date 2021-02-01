using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastShot : MonoBehaviour {
  public Transform solvedGuyTarget;

  void OnEnable () {
    Guy.Instance.Go(solvedGuyTarget);
    StartCoroutine(_EventuallySit());
  }

  IEnumerator _EventuallySit () {
    yield return new WaitForSeconds(3);
    Guy.Instance.animator.SetTrigger("Sit");
  }
}
