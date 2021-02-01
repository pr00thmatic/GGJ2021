using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoomEnding : MonoBehaviour {
  [Header("Initialization")]
  public GameObject firstLight;
  public GameObject secondRoom;
  public GameObject thirdRoom;
  public GameObject nextLevelCamera;
  public Transform solvedGuyTarget;

  void OnEnable () {
    secondRoom.SetActive(true);
    thirdRoom.SetActive(true);
    Guy.Instance.Go(solvedGuyTarget);
  }

  public void EnableFirstLight () {
    firstLight.SetActive(true);
    RewardSound.Instance.Play();
  }

  public void NextLevel () {
    nextLevelCamera.SetActive(true);
    gameObject.SetActive(false);
  }
}
