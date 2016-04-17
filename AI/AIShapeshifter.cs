using System.Collections.Generic;
using UnityEngine;

public enum Alertness {LOAF, AWARE, INTIMIDATED};

public class AIShapeshifter : AICreature {
  public static float MAX_AWARE_TRIGGER = 50;
  public static float MAX_INTIMIDATED_TRIGGER = 20;
  public static float MAX_CHASE_TRIGGER = 10;

  private EntityShapeshifter shapeshifter;

  private float timeSinceLastShapeshift;
  private float timeSinceLastSeen;
  private bool changingShape;

  private Alertness alertness;

  public AIShapeshifter(Main main, EntityShapeshifter shapeshifter, EntityPlayer player) : base(main, shapeshifter, player) {
    this.shapeshifter = shapeshifter;
    this.player = player;

    shapeshifter.alertness = Alertness.LOAF;
  }

  public override void OnUpdate() {
    double distance = Vector3.Distance(shapeshifter.transform.position, player.transform.position);

    timeSinceLastShapeshift += Time.deltaTime;
    timeSinceLastSeen += Time.deltaTime;

    if (IsSeen()) {
      timeSinceLastSeen = 0;
    }

    if(distance < MAX_INTIMIDATED_TRIGGER) {
      if(shapeshifter.alertness != Alertness.INTIMIDATED) {
        shapeshifter.alertness = Alertness.INTIMIDATED;
        shapeshifter.herd.RemoveMember(shapeshifter);
      }
    } else if(distance < MAX_AWARE_TRIGGER) {
      if(shapeshifter.alertness != Alertness.AWARE) {
        shapeshifter.alertness = Alertness.AWARE;
      }
    } else if(distance >= MAX_AWARE_TRIGGER) {
      if(shapeshifter.alertness != Alertness.LOAF) {
        shapeshifter.alertness = Alertness.LOAF;
      }
    }

    switch(shapeshifter.alertness) {
      case Alertness.LOAF:
        OnLoafUpdate();
        break;
      case Alertness.AWARE:
        OnAwareUpdate();
        break;
      case Alertness.INTIMIDATED:
        OnIntimidatedUpdate();
        break;

    }
  }

  public override void OnLoafUpdate() {
    if(shapeshifter.herd != null) {
      shapeshifter.herd.RemoveMember(shapeshifter);
    }
    MovementUpdate();

    if (timeSinceLastSeen > 3.0f & timeSinceLastShapeshift > 12.0f) {
      shapeshift(CreatureType.CREATURE_TYPES[Random.Range(0, CreatureType.CREATURE_TYPES.Count)]);
    }
  }

  public void OnAwareUpdate() {
    //shapeshifter.speed = new Vector3(0, 0, 0);
    if(shapeshifter.herd == null) {
      FindNewHerd(45);
      changingShape = true;
    }
    if (changingShape) {
      if (timeSinceLastSeen > 2 & Vector3.Distance(shapeshifter.transform.position, shapeshifter.herd.transform.position) > shapeshifter.herd.radius) {
        shapeshift(shapeshifter.herd.creatureType);
        changingShape = false;
      }
    }

    MovementUpdate();
  }

  public void OnIntimidatedUpdate() {
    if(shapeshifter.herd == null) {
      FindNewHerd(100);
    }

    MovementUpdate();
  }

  public void FindNewHerd(float angle) {
    List<EntityHerd> potentialHerds = new List<EntityHerd>();

    for(int i = 0; i < main.herds.Count; i++) {
      if(Vector3.Distance(main.herds[i].transform.position, shapeshifter.transform.position) <= 400/* && Vector3.Angle(player.transform.position - shapeshifter.transform.position, main.herds[i].transform.position - shapeshifter.transform.position) > angle */ && (shapeshifter.herd == null || shapeshifter.herd != main.herds[i])) {
        potentialHerds.Add(main.herds[i]);
      }
    }

    if(potentialHerds.Count >= 1) {
      potentialHerds[(int)Mathf.Round(Random.Range(0.0F, potentialHerds.Count - 1))].AddMember(shapeshifter);
    } else {
      Debug.Log("0 herds");
    }



    //loafPoint = herd.transform.position;
    remainingRestTime = 2F;
    shapeshifter.SetResting();
    FindNewTarget();
  }

  public bool IsSeen() {
    return shapeshifter.GetComponentInChildren<SkinnedMeshRenderer>().isVisible;
  }

  public void shapeshift(CreatureType creatureType) {
    shapeshifter.shapeshift(creatureType);
    timeSinceLastShapeshift = 0;
  }
}
