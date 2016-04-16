using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

  public Main main;

  private Vector3 defaultCursorPos;

  void Start()
  {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
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

    main.entityPlayer.speed = new Vector3(x, 0, z) * 100;


    Debug.Log(Input.GetAxis("Mouse Y"));
    Debug.Log(Input.GetAxis("Mouse X"));

    main.entityPlayer.transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X"), 0);
    main.entityPlayer.transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);



  }

}
