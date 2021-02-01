using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCameras : MonoBehaviour {
  [Header("Configuration")]
  public float timetoNextLevel = 3;

  [Header("Initialization")]
  public GameObject controllableCamera;
  public GameObject solvedCamera;
  public GameObject nextCamera;
  public CameraSolutionChecker cam;

  void Reset () {
    cam = Camera.main.GetComponent<CameraSolutionChecker>();
  }

  void OnEnable () {
    cam.onRoomSolved += HandleSolution;
  }

  void OnDisable () {
    cam.onRoomSolved -= HandleSolution;
  }

  public void HandleSolution (CameraSolution solved) {
    if (solved.GetComponentInParent<LevelRoot>() !=
        GetComponentInParent<LevelRoot>()) return;
    controllableCamera.SetActive(false);
    solvedCamera.SetActive(true);
    if (nextCamera) {
      StartCoroutine(_NextLevel());
    }
  }
  IEnumerator _NextLevel () {
    yield return new WaitForSeconds(timetoNextLevel);
    nextCamera.SetActive(true);
  }
}
