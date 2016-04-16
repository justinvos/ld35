using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

	public GameObject gabbit;

	public static Random RANDOM = new Random();

	public InputHandler inputHandler;
	public EntityPlayer entityPlayer;

	public List<AIHerd> herds;

	void Start() {
		inputHandler = new GameObject("inputHandler").AddComponent<InputHandler>();
		inputHandler.main = this;

		herds = new List<AIHerd>();

		entityPlayer = new GameObject("player").AddComponent<EntityPlayer>();
		entityPlayer.transform.position = new Vector3(0, 1, 0);
		Camera.main.transform.parent = entityPlayer.transform;

		GameObject shapeshifter = new GameObject("Shapeshifter");
		shapeshifter.transform.position = new Vector3(40, 1, 40);
		shapeshifter.AddComponent<EntityShapeshifter>();

		AIHerd herd = new AIHerd(new Vector3(30, 1, 0));
		herds.Add(herd);

		for(int i = 0; i < 7; i++) {
			GameObject testCreature = new GameObject("testCreature" + i);
			testCreature.transform.position = new Vector3(20, 1, 3*i);
			testCreature.AddComponent<EntityGabbit>().SetHerd(herd);
		}

	}

	void Update() {}

}
