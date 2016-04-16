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


		GameObject shapeshifter = new GameObject("Shapeshifter");
		shapeshifter.transform.position = new Vector3(40, 1, 40);
		shapeshifter.AddComponent<EntityShapeshifter>();

		GameObject testCreature = new GameObject("testCreature");
		testCreature.transform.position = new Vector3(10, 1, 10);
		testCreature.AddComponent<EntityCreature>();

	}

	// Update is called once per frame
	void Update() {

	}

}
