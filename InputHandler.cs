using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

  public Main main;
  public static float mouseSensitivity;

  public static bool isPause;

  void Start() {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
    mouseSensitivity = 2;
    isPause = false;
  }

  void Update() {

    // Movement
    float x = 0, z = 0;
    if (Input.GetKey(KeyCode.W)) { z++; }
    if (Input.GetKey(KeyCode.A)) { x--; }
    if (Input.GetKey(KeyCode.S)) { z--; }
    if (Input.GetKey(KeyCode.D)) { x++; }
    main.entityPlayer.speed = new Vector3(x, 0, z) * 3;

    // Camera rotation
    if (!isPause) {
      main.entityPlayer.transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X"), 0) * 0.75f * mouseSensitivity;
      Camera.main.transform.eulerAngles -= new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * mouseSensitivity;
    }

    // Pause menu
    if (Input.GetKeyDown(KeyCode.Escape)) {
      isPause = !isPause;
      Cursor.visible = !Cursor.visible;
      if (isPause) {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
      } else {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
      }
    }

  }

}
