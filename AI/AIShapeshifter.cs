using System.Collections.Generic;
using UnityEngine;

public enum Alertness {LOAF, AWARE, INTIMIDATED, CHASE};

public class AIShapeshifter : AICreature {
  public static float MAX_AWARE_TRIGGER = 50;
  public static float MAX_INTIMIDATED_TRIGGER = 20;
  public static float MAX_CHASE_TRIGGER = 10;

  private EntityShapeshifter shapeshifter;

  private float timeSinceLastShapeshift;
  private float timeSinceLastSeen;

  private Alertness alertness;

  public AIShapeshifter(Main main, EntityShapeshifter shapeshifter, EntityPlayer player) : base(main, shapeshifter, player) {
    this.shapeshifter = shapeshifter;
    this.player = player;

    shapeshifter.alertness = Alertness.LOAF;
  }

  public override void OnUpdate() {
    double distance = Vector3.Distance(shapeshifter.transform.position, player.transform.position);
    timeSinceLastShapeshift += Time.deltaTime;

    if(distance < MAX_CHASE_TRIGGER) {
      if(shapeshifter.alertness != Alertness.CHASE) {
        shapeshifter.alertness = Alertness.CHASE;
      }
    } else if(distance < MAX_INTIMIDATED_TRIGGER) {
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
      case Alertness.CHASE:
        OnChaseUpdate();
        break;
    }
  }

  public override void OnLoafUpdate() {
    if(shapeshifter.herd != null) {
      shapeshifter.herd.RemoveMember(shapeshifter);
    }
    MovementUpdate();

    if (!IsSeen() & timeSinceLastShapeshift > 15.0f) {
      if (timeSinceLastSeen > 3.0f) {
        shapeshifter.shapeshift(CreatureType.CREATURE_TYPES[Random.Range(0, CreatureType.CREATURE_TYPES.Count)]);
        timeSinceLastShapeshift = 0;
        Debug.Log("Shapeshifter shifted its shape");
      } else {
        timeSinceLastSeen += Time.deltaTime;
      }
    } else {
      timeSinceLastSeen = 0;
    }
  }

  public void OnAwareUpdate() {
    //shapeshifter.speed = new Vector3(0, 0, 0);
    if(shapeshifter.herd == null) {
      FindNewHerd(45);
    }

    MovementUpdate();
  }

  public void OnIntimidatedUpdate() {
    if(shapeshifter.herd == null) {
      FindNewHerd(100);
    }

    MovementUpdate();
  }

  public void OnChaseUpdate() {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public void FindNewHerd(float angle) {
    List<EntityHerd> potentialHerds = new List<EntityHerd>();

    for(int i = 0; i < main.herds.Count; i++) {
      if(Vector3.Distance(main.herds[i].transform.position, shapeshifter.transform.position) <= 400 && Vector3.Angle(player.transform.position - shapeshifter.transform.position, main.herds[i].transform.position - shapeshifter.transform.position) > angle && (shapeshifter.herd == null || shapeshifter.herd != main.herds[i])) {
        potentialHerds.Add(main.herds[i]);
      }
    }

    potentialHerds[(int)Mathf.Round(Random.Range(0.0F, potentialHerds.Count - 1))].AddMember(shapeshifter);



    //loafPoint = herd.transform.position;
    remainingRestTime = 2F;
    shapeshifter.SetResting();
    FindNewTargetWhileLoafing();
  }

  public bool IsSeen() {
    MeshRenderer mr;
    SkinnedMeshRenderer smr;
    if ((mr = shapeshifter.GetComponentInChildren<MeshRenderer>()) != null) {
      return mr.isVisible;
    } else if ((smr = shapeshifter.GetComponentInChildren<SkinnedMeshRenderer>()) != null) {
      return smr.isVisible;
    } else {
      return false;
    }
  }
}
