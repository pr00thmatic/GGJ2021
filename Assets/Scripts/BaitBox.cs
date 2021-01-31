using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitBox : MonoBehaviour {
  public event System.Action onSolved;

  [Header("Configuration")]
  public float baitSolveWait = 0.6f;

  [Header("Initialization")]
  public Animator box;
  public Animator bait;
  public Renderer r;

  void OnMouseUpAsButton () {
    box.SetTrigger("Open");
    StartCoroutine(_SolveBait());
  }

  IEnumerator _SolveBait () {
    yield return new WaitForSeconds(baitSolveWait);
    float t = 0;
    while (t < 0.4) {
      r.materials[0].color = Color.Lerp(Color.white, new Color(1,1,1, 0), t / 0.4f);
      t += Time.deltaTime;
      yield return null;
    }
    bait.SetTrigger("Solve");
    box.gameObject.SetActive(false);
    onSolved?.Invoke();
  }
}
