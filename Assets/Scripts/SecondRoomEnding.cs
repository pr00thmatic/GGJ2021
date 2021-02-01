using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRoomEnding : MonoBehaviour {
  [Header("Initialization")]
  public Transform solvedGuyTarget;
  public GameObject fireLight;
  public GameObject nextLevelCamera;

  void OnEnable () {
    Guy.Instance.Go(solvedGuyTarget);
  }

  public void TurnFireOn () {
    fireLight.SetActive(true);
  }

  public void NextLevel () {
    nextLevelCamera.SetActive(true);
    gameObject.SetActive(false);
  }
}
