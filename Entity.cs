using UnityEngine;

public class Entity : MonoBehaviour {

  public CharacterController characterController;
  public Vector3 speed;

  public void Start() {
    characterController = gameObject.AddComponent<CharacterController>();
  }

  public void Update() {
    characterController.SimpleMove(Time.deltaTime * speed);
  }
}