using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamView : MonoBehaviour {
  public Vector2 speed = new Vector2(360, 180);

  void Update () {
    if (Input.GetMouseButton(1) || Input.GetMouseButton(2)) {
      transform.Rotate(-Input.GetAxis("Mouse Y") * speed.x,
                       Input.GetAxis("Mouse X") * speed.y, 0);
      transform.rotation = Quaternion.Euler(Vector3.Scale(transform.rotation.eulerAngles, new Vector3(1,1,0)));
    }
  }
}
