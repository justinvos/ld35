using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public InputHandler inputHandler;
	public EntityPlayer entityPlayer;

	// Use this for initialization
	void Start() {
		inputHandler = new GameObject("inputHandler").AddComponent<InputHandler>();
		inputHandler.main = this;

		entityPlayer = new GameObject("player").AddComponent<EntityPlayer>();
		Camera.main.transform.parent = entityPlayer.transform;
	}

	// Update is called once per frame
	void Update() {

	}

}
