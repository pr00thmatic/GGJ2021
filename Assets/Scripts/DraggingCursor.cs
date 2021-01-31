using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingCursor : MonoBehaviour {
  [Header("Configuration")]
  public float moveSpeed = 5;

  [Header("Information")]
  public Movable selected;

  void Update () {
    if (Input.GetMouseButtonDown(0)) {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Clickable"))) {
        Movable m = hit.collider.GetComponent<Movable>();
        if (m) {
          selected = m;
          m.Select();
        }
      }
    }

    if (Input.GetMouseButtonUp(0) && selected) {
      selected.Deselect();
      selected = null;
    }

    if (selected && Input.GetMouseButton(0)) {
      selected.Move((Viewport.Right * Input.GetAxis("Mouse X") +
                     Viewport.Up * Input.GetAxis("Mouse Y") +
                     Viewport.Forward * Input.GetAxis("Mouse Y")), moveSpeed);
    }

    Cursor.visible = !selected;
  }
}
