using UnityEngine;

public enum Alertness {LOAF, AWARE, INTIMIDATED, CHASE};

public class AIShapeshifter : AICreature {
  public static float MAX_AWARE_TRIGGER = 30;
  public static float MAX_INTIMIDATED_TRIGGER = 10;
  public static float MAX_CHASE_TRIGGER = 4;

  private EntityShapeshifter shapeshifter;

  private Alertness alertness;

  private Vector3 loafPoint;
  private Vector3 currentTarget;
  private float remainingRestTime;

  public AIShapeshifter(Main main, EntityShapeshifter shapeshifter, EntityPlayer player) : base(main, shapeshifter, player) {
    this.shapeshifter = shapeshifter;
    this.player = player;

    alertness = Alertness.LOAF;

    loafPoint = shapeshifter.transform.position;
    currentTarget = shapeshifter.transform.position;
  }

  public override void OnUpdate() {
    double distance = Vector3.Distance(shapeshifter.transform.position, player.transform.position);

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
  }

  public override void OnLoafUpdate() {

    if(remainingRestTime > 0) {
      remainingRestTime = remainingRestTime - Time.deltaTime;

      if(remainingRestTime <= 0) {
        remainingRestTime = 0;

        if(herd != null) {
          loafPoint = herd.position;
        }

        currentTarget = new Vector3(Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS, 1, Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS) + loafPoint;

        shapeshifter.transform.LookAt(currentTarget);

        shapeshifter.speed = new Vector3(0,0,1);
      }
    }
    else if(Vector3.Distance(currentTarget, shapeshifter.transform.position) < 1) {
      remainingRestTime = UnityEngine.Random.Range(2.0F, 5.0F);
      shapeshifter.speed = new Vector3(0,0,0);
    }
    else {
      shapeshifter.speed = new Vector3(0,0,1); // Eventually move to OnLoafStart() event handler
    }
  }

  public void OnAwareUpdate() {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public void OnIntimidatedUpdate() {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public void OnChaseUpdate() {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public void FindNewHerdWhileAware() {

  }

  public void FindNewHerdWhileIntimidated() {

  }

  public bool IsSeen() {
    return shapeshifter.mesh.GetComponent<Renderer>().isVisible;
  }
}
