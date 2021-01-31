using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://answers.unity.com/questions/330661/setting-the-mouse-position-to-specific-coordinates.html
// @zachwuzhere
//C#
using System.Runtime.InteropServices;

public class DraggingCursor : MonoBehaviour {
  [Header("Configuration")]
  public float moveSpeed = 5;
  public float buildMoveSpeed = 10;

  [Header("Information")]
  public Movable selected;
  public Vector2 mousePosition;
  [DllImport("user32.dll")]
  static extern bool SetCursorPos(int X, int Y);

  void Update () {
    if (Input.GetMouseButtonDown(0)) {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Clickable"))) {
        Movable m = hit.collider.GetComponent<Movable>();
        if (m) {
          selected = m;
          m.Select();
          Cursor.lockState = CursorLockMode.Locked;
          // mousePosition = GUIUtility.ScreenToGUIPoint(Input.mousePosition);
          // mousePosition = Input.mousePosition;
        }
      }
    }

    if (Input.GetMouseButtonUp(0) && selected) {
      selected.Deselect();
      selected = null;
      Cursor.lockState = CursorLockMode.None;
      // SetCursorPos((int) mousePosition.x, (int) mousePosition.y);
    }

    if (selected && Input.GetMouseButton(0)) {
      float s;
      #if UNITY_EDITOR
      s = moveSpeed;
      #else
      s = buildMoveSpeed;
      #endif
      selected.Move((Viewport.Right * Input.GetAxis("Mouse X") +
                     Viewport.Up * Input.GetAxis("Mouse Y") +
                     Viewport.Forward * Input.GetAxis("Mouse Y")), s);
    }

    Cursor.visible = !selected;
  }
}
