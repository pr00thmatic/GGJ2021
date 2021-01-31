using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewport : NonPersistentSingleton<Viewport> {
  public static Vector3 Forward { get => Utils.CoplanarToFloor(Instance.transform.forward); }
  public static Vector3 Right { get => Utils.CoplanarToFloor(Instance.transform.right); }
  public static Vector3 Up { get => Vector3.up; }
}
