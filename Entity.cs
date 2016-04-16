using System;
using UnityEngine;

public class Entity : MonoBehaviour {

  public CharacterController characterController;
  public Vector3 speed;

  public virtual void Start() {
    characterController = gameObject.AddComponent<CharacterController>();
  }

  public void Update() {
    characterController.SimpleMove(transform.TransformDirection(speed));
  }
}
