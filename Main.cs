using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

	public GameObject gabbit;
	public GameObject lizard;
	public GameObject bear;

	public static Random RANDOM = new Random();

	public InputHandler inputHandler;
	public EntityPlayer entityPlayer;

	public World world;

	public List<EntityHerd> herds;

	void Start() {
		inputHandler = new GameObject("inputHandler").AddComponent<InputHandler>();
		inputHandler.main = this;

		herds = new List<EntityHerd>();

		entityPlayer = new GameObject("player").AddComponent<EntityPlayer>();
		entityPlayer.transform.position = new Vector3(0, 1, 0);
		Camera.main.transform.parent = entityPlayer.transform;

		world = new World(this);

		GameObject shapeshifterGameObject = Spawn("shapeshifter", CreatureType.CREATURE_TYPES[Random.Range(0, CreatureType.CREATURE_TYPES.Count)], new Vector3(40, 1, 40), 0);
		EntityShapeshifter shapeshifter = shapeshifterGameObject.AddComponent<EntityShapeshifter>();
		shapeshifter.ai = new AIShapeshifter(this, shapeshifter, entityPlayer);


		world.SpawnHerd(CreatureType.GABBIT, 7, 20);

		world.SpawnHerd(CreatureType.BEAR, 3, 20);

		world.SpawnHerd(CreatureType.GABBIT, 7, 20);

		/*AIHerd herd = new AIHerd(new Vector3(30, 1, 0));
		herds.Add(herd);

		for(int i = 0; i < 7; i++) {
			GameObject testCreature = new GameObject("testCreature" + i);
			testCreature.transform.position = new Vector3(20, 1, 3*i);
			testCreature.AddComponent<EntityGabbit>().SetHerd(herd);
		}*/

	}

	void Update() {}


	public GameObject Spawn(string label, CreatureType creatureType, Vector3 position, float rotation) {
    GameObject go = Instantiate(creatureType.GetPrefab());
		go.name = label;
    go.transform.position = position;
    go.transform.Rotate(0, rotation, 0);

    return go;
  }

}
