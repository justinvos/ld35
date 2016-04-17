using System;
using UnityEngine;

public class Entity : MonoBehaviour {

  public CharacterController characterController;
  public Vector3 speed;
  public float angularVelocity;

  protected Main main;

  public virtual void Awake()
  {
    main = GameObject.Find("Main").GetComponent<Main>();
    characterController = gameObject.AddComponent<CharacterController>();
  }

  public virtual void Update() {
    characterController.SimpleMove(transform.TransformDirection(speed));
    transform.Rotate(0, angularVelocity * Time.deltaTime, 0);
  }

  public void SetResting()
  {
    speed = Vector3.zero;
  }

  public bool IsResting() {
    return speed == Vector3.zero;
  }
}
