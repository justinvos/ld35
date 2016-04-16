using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

  public Main main;


  void Start()
  {

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
    //main.entityPlayer.transform.Translate(Time.deltaTime * x, 0, Time.deltaTime * z);
  }

}
