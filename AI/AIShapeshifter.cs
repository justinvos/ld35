using System.Collections.Generic;
using UnityEngine;

public enum Alertness {LOAF, AWARE, INTIMIDATED, CHASE};

public class AIShapeshifter : AICreature {
  public static float MAX_AWARE_TRIGGER = 30;
  public static float MAX_INTIMIDATED_TRIGGER = 10;
  public static float MAX_CHASE_TRIGGER = 4;

  private EntityShapeshifter shapeshifter;

  private float timeSinceLastShapeshift;

  private Alertness alertness;

  public AIShapeshifter(Main main, EntityShapeshifter shapeshifter, EntityPlayer player) : base(main, shapeshifter, player) {
    this.shapeshifter = shapeshifter;
    this.player = player;

    alertness = Alertness.LOAF;
  }

  public override void OnUpdate() {
    double distance = Vector3.Distance(shapeshifter.transform.position, player.transform.position);
    timeSinceLastShapeshift += Time.deltaTime;

    if(distance < MAX_CHASE_TRIGGER) {
      alertness = Alertness.CHASE;
    } else if(distance < MAX_INTIMIDATED_TRIGGER) {
      alertness = Alertness.INTIMIDATED;
    } else if(distance < MAX_AWARE_TRIGGER) {
      alertness = Alertness.AWARE;
    } else {
      alertness = Alertness.LOAF;
    }

    switch(alertness) {
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

    if (!IsSeen() & timeSinceLastShapeshift > 15.0f) {
      shapeshifter.shapeshift(CreatureType.CREATURE_TYPES[Random.Range(0, CreatureType.CREATURE_TYPES.Count)]);
      timeSinceLastShapeshift = 0;
    }
  }

  public void OnAwareUpdate() {
    //shapeshifter.speed = new Vector3(0, 0, 0);
    FindNewHerdWhileAware();

    OnLoafUpdate();

  }

  public void OnIntimidatedUpdate() {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public void OnChaseUpdate() {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public void FindNewHerdWhileAware() {
    List<AIHerd> potentialHerds = new List<AIHerd>();

    for(int i = 0; i < main.herds.Count; i++) {
      if(Vector3.Distance(main.herds[i].position, shapeshifter.transform.position) <= 200 && Vector3.Angle(player.transform.position - shapeshifter.transform.position, main.herds[i].position - shapeshifter.transform.position) > 45) {
        potentialHerds.Add(main.herds[i]);
      }
    }

    herd = potentialHerds[(int)Mathf.Round(Random.Range(0.0F, potentialHerds.Count))];
  }

  public void FindNewHerdWhileIntimidated() {

  }

  public bool IsSeen() {
    //return shapeshifter.mesh.GetComponent<Renderer>().isVisible;
    return false;
  }
}
