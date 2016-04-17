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


    // Capturing
    /*if(Input.GetMouseButtonDown(0)) {
      Debug.Log("CLICK");
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (main.entityPlayer.gameObject.GetComponent<Collider>().Raycast(ray, out hit, 3.0F)) {
        Debug.Log("hit " + hit.transform.gameObject.name);

        if(hit.transform.gameObject.GetComponent<EntityShapeshifter>() != null) {
          Debug.Log("SHAPESHIFTER");
        }
        else if(hit.transform.gameObject.GetComponent<EntityCreature>() != null) {
          Debug.Log("CREATURE");
        }
      }
    }*/

    RaycastHit hit;

    if(Input.GetMouseButtonDown(0)) {
      if (Physics.Raycast(main.entityPlayer.transform.position, main.entityPlayer.transform.forward, out hit)) {

        if(hit.transform.gameObject.GetComponent<EntityShapeshifter>() != null) {
          Debug.Log("SS");
        } else if(hit.transform.gameObject.GetComponent<EntityCreature>() != null) {
          Debug.Log("C");
        }
      }

    }


  }

}
