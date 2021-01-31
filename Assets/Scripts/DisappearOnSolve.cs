using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnSolve : MonoBehaviour {
  [Header("Configuration")]
  public float acceleration = 3;
  public float maxSpeed = 6;

  [Header("Information")]
  public bool goingAway = false;
  public float speed = 0;

  [Header("Initialization")]
  public CameraSolutionChecker solutionChecker;

  void OnEnable () {
    solutionChecker.onRoomSolved += HandleSolution;
  }

  void OnDisable () {
    solutionChecker.onRoomSolved -= HandleSolution;
  }

  void Update () {
    if (goingAway) {
      transform.position += Vector3.up * speed * Time.deltaTime;
      if (speed < maxSpeed) {
        speed += acceleration * Time.deltaTime;
      } else {
        speed = maxSpeed;
      }
    }
  }

  public void HandleSolution (CameraSolution solved) {
    if (solved.GetComponentInParent<LevelRoot>() != GetComponentInParent<LevelRoot>()) return;
    StartCoroutine(_GoAway());
  }
  IEnumerator _GoAway () {
    GetComponent<Movable>().enabled = false;
    yield return new WaitForSeconds(Random.Range(0.3f, 1f));
    goingAway = true;
    yield return new WaitForSeconds(2);
    Destroy(gameObject);
  }
}
