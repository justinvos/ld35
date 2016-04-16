using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public static Random RANDOM = new Random();

	public InputHandler inputHandler;
	public EntityPlayer entityPlayer;

	// Use this for initialization
	void Start() {
		inputHandler = new GameObject("inputHandler").AddComponent<InputHandler>();
		inputHandler.main = this;

		entityPlayer = new GameObject("player").AddComponent<EntityPlayer>();
		entityPlayer.transform.position = new Vector3(0, 1, 0);
		Camera.main.transform.parent = entityPlayer.transform;


		GameObject go = new GameObject("Shapeshifter");
		go.transform.position = new Vector3(10, 1, 10);
		go.AddComponent<EntityShapeshifter>();
	}

	// Update is called once per frame
	void Update() {

	}

}
