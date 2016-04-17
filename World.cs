using UnityEngine;

public class World {
  public Main main;

  public World(Main main) {
    this.main = main;
  }

  public void Generate() {

  }

  public void SpawnHerd(CreatureType creatureType, int n, float radius) {

    AIHerd herd = new AIHerd(new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)));
    //s
    for(int i = 0; i < n; i++) {
      main.SpawnCreature(creatureType, new Vector3(Random.Range(-radius, radius), 1.0F, Random.Range(-radius, radius)), Random.Range(0, 360));
    }
  }


}
