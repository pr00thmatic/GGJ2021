using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
  [Header("Configuration")]
  public float deltaSmoothTime = 0.2f;
  public float smoothOutlineTime = 0.4f;
  public Color invalidOutlineColor = Color.red;

  [Header("Information")]
  public Vector3 delta;
  public Vector3 rawDelta;
  public Vector3 deltaSmoothVelocity;
  public Vector3 lastPosition;
  public float outlineTarget = 0;
  public float smoothedOutline;
  public float smoothOutlineSpeed = 0;
  public Color originalOutlineColor;

  [Header("Initialization")]
  public Transform direction;
  public Rigidbody body;
  public Outline outline;

  void Reset () {
    if (transform.childCount == 0) {
      direction = new GameObject("direction").transform;
      direction.parent = transform;
      direction.localPosition = Vector3.zero;
      direction.localRotation = Quaternion.identity;
    } else {
      direction = transform.Find("direction");
    }
    body = GetComponent<Rigidbody>();
    if (!body) {
      body = gameObject.AddComponent<Rigidbody>();
      body.isKinematic = true;
      body.useGravity = false;
    }
    outline = GetComponent<Outline>();
    if (!outline) {
      outline = gameObject.AddComponent<Outline>();
    }
    originalOutlineColor = outline.OutlineColor;
  }

  void Awake () {
    lastPosition = transform.position;
    outline.OutlineWidth = 0;
  }

  void FixedUpdate () {
    Vector3 deltaP = transform.position - lastPosition;
    float angle = Vector3.Angle(deltaP.normalized, direction.forward.normalized);
    if (angle < 179 && angle > 1) {
      transform.position = lastPosition;
      deltaSmoothVelocity = Vector3.zero;
      delta = Vector3.zero;
      outline.OutlineColor = invalidOutlineColor;
    } else {
      outline.OutlineColor = originalOutlineColor;
    }
    lastPosition = transform.position;
  }

  void Update () {
    delta = Vector3.SmoothDamp(delta, rawDelta, ref deltaSmoothVelocity, deltaSmoothTime);
    outline.OutlineWidth = smoothedOutline =
      Mathf.SmoothDamp(smoothedOutline, outlineTarget, ref smoothOutlineSpeed, smoothOutlineTime);
    outline.enabled = outline.OutlineWidth > 0.1f;
  }

  public void Move (Vector3 delta, float speed) {
    this.rawDelta = Vector3.Project(delta, direction.forward).normalized * speed * Time.deltaTime *
      Screen.width / 1920;
    body.MovePosition(transform.position + this.delta);
  }

  public void Select () {
    body.isKinematic = false;
    outlineTarget = 5;
  }

  public void Deselect () {
    body.isKinematic = true;
    rawDelta = Vector3.zero;
    outlineTarget = 0;
  }
}
