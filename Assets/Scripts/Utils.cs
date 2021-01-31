using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {
  public static float NormalizeAngle (float degrees) {
    return (degrees + 360 * (degrees / 360)) % 360;
  }

  public static Vector3 CoplanarToFloor (Vector3 v) {
    return Vector3.Scale(v, new Vector3(1,0,1));
  }

  public static Vector3 UnsetZ (Vector3 v) {
    return SetZ(v, 0);
  }

  public static Vector3 SetZ (Vector3 v, float z) {
    v.z = z;
    return v;
  }
}
