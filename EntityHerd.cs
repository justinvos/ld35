
using System.Collections.Generic;
using UnityEngine;

public class EntityHerd : MonoBehaviour {
  public CreatureType creatureType;
  public float radius;

  public List<EntityCreature> creatures;
  public AIHerd ai;

  void Awake(){
    creatures = new List<EntityCreature>();

    ai = new AIHerd(this);
  }

  void Update() {
    ai.OnUpdate();
  }

  public void AddMember(EntityCreature creature) {
    creatures.Add(creature);
    creature.herd = this;
  }

  public void RemoveMember(EntityCreature creature) {
    creatures.Remove(creature);
    creature.herd = null;
  }
}
