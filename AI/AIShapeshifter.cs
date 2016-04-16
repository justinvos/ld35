using UnityEngine;

public enum Alertness {LOAF, AWARE, INTIMIDATED, CHASE};

public class AIShapeshifter
{
  public static float MAX_AWARE_TRIGGER = 30;
  public static float MAX_INTIMIDATED_TRIGGER = 10;
  public static float MAX_CHASE_TRIGGER = 4;

  public static float LOAFING_RADIUS = 20;

  private EntityPlayer player;

  private EntityShapeshifter shapeshifter;
  private Alertness alertness;

  private Vector3 loafPoint;
  private Vector3 currentTarget;
  private float remainingRestTime;

  public AIShapeshifter(EntityShapeshifter shapeshifter, EntityPlayer player)
  {
    this.shapeshifter = shapeshifter;
    this.player = player;

    alertness = Alertness.LOAF;

    loafPoint = shapeshifter.transform.position;
    currentTarget = shapeshifter.transform.position;
  }

  public void OnUpdate()
  {
    double distance = Vector3.Distance(shapeshifter.transform.position, player.transform.position);

    if(distance < MAX_CHASE_TRIGGER) {
      alertness = Alertness.CHASE;
    } else if(distance < MAX_INTIMIDATED_TRIGGER) {
      alertness = Alertness.INTIMIDATED;
    } else if(distance < MAX_AWARE_TRIGGER) {
      alertness = Alertness.AWARE;
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

  public void OnLoafUpdate() {
    
    if(remainingRestTime > 0) {
      remainingRestTime = remainingRestTime - Time.deltaTime;

      if(remainingRestTime <= 0) {
        remainingRestTime = 0;

        currentTarget = new Vector3(Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS, 1, Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS) + loafPoint;

        shapeshifter.transform.LookAt(currentTarget);

        shapeshifter.speed = new Vector3(0,0,1);
      }
    }
    else if(Vector3.Distance(currentTarget, shapeshifter.transform.position) < 1) {
      remainingRestTime = UnityEngine.Random.Range(2.0F, 5.0F);
      shapeshifter.speed = new Vector3(0,0,0);
    }
  }

  public void OnAwareUpdate()
  {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public void OnIntimidatedUpdate()
  {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public void OnChaseUpdate()
  {
    shapeshifter.speed = new Vector3(0, 0, 0);
  }

  public bool IsSeen() {
    return shapeshifter.mesh.GetComponent<Renderer>().isVisible;
  }
}
