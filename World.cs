using UnityEngine;

public class World {
  public Main main;

  public World(Main main) {
    this.main = main;
  }

  public void Generate() {

  }

  public void SpawnHerd(CreatureType creatureType, int n, float radius) {

    EntityHerd herd = new GameObject("herd").AddComponent<EntityHerd>();

    herd.creatureType = creatureType;

    herd.radius = radius;

    main.herds.Add(herd);

    herd.transform.position = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));

    for(int i = 0; i < n; i++) {
      GameObject go = main.Spawn(creatureType.GetLabel() + i, creatureType, new Vector3(herd.transform.position.x + Random.Range(-radius, radius), 1.0F, herd.transform.position.z + Random.Range(-radius, radius)), Random.Range(0, 360));

      EntityCreature creature = go.AddComponent<EntityCreature>();

      creature.creatureType = creatureType;
  		creature.ai = new AICreature(main, creature, main.entityPlayer);

      herd.AddMember(creature);
    }

  }


}
