
using System.Collections.Generic;
using UnityEngine;

public class EntityHerd : MonoBehaviour {
  public CreatureType creatureType;
  public float radius;

  public List<EntityCreature> creatures;

  void Awake(){
    creatures = new List<EntityCreature>();
  }

  public void AddMember(EntityCreature creature) {
    creatures.Add(creature);
    creature.herd = this;
  }
}
