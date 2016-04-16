using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

  public Main main;
  public CharacterController characterController;

  void Start()
  {
    characterController = main.entityPlayer.gameObject.AddComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update() {
    float x = 0, z = 0;
    if (Input.GetKey(KeyCode.W)) {
      z++;
    }
    if (Input.GetKey(KeyCode.S)) {
      z--;
    }
    if (Input.GetKey(KeyCode.D)) {
      x++;
    }
    if (Input.GetKey(KeyCode.A)) {
      x--;
    }

    characterController.SimpleMove(new Vector3(Time.deltaTime * x, 0, Time.deltaTime * z) * 100);
    //main.entityPlayer.transform.Translate(Time.deltaTime * x, 0, Time.deltaTime * z);
  }

}
