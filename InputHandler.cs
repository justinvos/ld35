using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

  public Main main;
  public float mouseSensitivity;

  void Start() {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
    mouseSensitivity = 2;
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

    main.entityPlayer.speed = new Vector3(x, 0, z) * 3;

    main.entityPlayer.transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X"), 0) * 0.75f * mouseSensitivity;
    Camera.main.transform.eulerAngles -= new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * mouseSensitivity;

  }

}
