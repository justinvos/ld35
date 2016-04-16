using UnityEngine;

public enum Alertness {LOAF, AWARE, INTIMIDATED, CHASE};

public class AIShapeshifter
{
  public static float LOAF_RADIUS = 20;

  private EntityPlayer player;

  private EntityShapeshifter shapeshifter;
  private Alertness alertness;

  private Vector3 loafPoint;
  private Vector3 currentTarget;

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

    /*if(distance < 5) {
      alertness = Alertness.CHASE;
    } else if(distance < 10) {
      alertness = Alertness.INTIMIDATED;
    } else if(distance < 20) {
      alertness = Alertness.AWARE;
    }*/

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

  public void OnLoafUpdate()
  {
    double distanceFromLoafPoint = Vector3.Distance(loafPoint, shapeshifter.transform.position);

    if(distanceFromLoafPoint > 20)
    {
      shapeshifter.transform.LookAt(loafPoint);
      shapeshifter.speed = new Vector3(0,0,1);
    }
    else if(Vector3.Distance(currentTarget, shapeshifter.transform.position) < 1)
    {
      currentTarget = new Vector3(Random.Range(-1.0f, 1.0f) * LOAF_RADIUS, 1, Random.Range(-1.0f, 1.0f) * LOAF_RADIUS) + shapeshifter.transform.position;

      shapeshifter.transform.LookAt(currentTarget);

      shapeshifter.speed = new Vector3(0,0,1);

    }
  }

  public void OnAwareUpdate()
  {

  }

  public void OnIntimidatedUpdate()
  {

  }

  public void OnChaseUpdate()
  {

  }

}
