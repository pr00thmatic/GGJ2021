using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guy : NonPersistentSingleton<Guy> {
  [Header("Information")]
  public Transform target;

  [Header("Initialization")]
  public NavMeshAgent agent;

  void Update () {
    if (target && agent.velocity.magnitude < 0.1f) {
      transform.forward = target.forward;
    }
  }

  public void Go (Transform target) {
    this.target = target;
    agent.SetDestination(target.position);
  }
}
