using System;
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
  private float elaspedStopTime;

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

  public void OnLoafUpdate()
  {
    double distanceFromLoafPoint = Vector3.Distance(loafPoint, shapeshifter.transform.position);


    if(elaspedStopTime > 0)
    {
      elaspedStopTime = elaspedStopTime - Time.deltaTime;

      elaspedStopTime = Math.Max(0, elaspedStopTime);

      if(elaspedStopTime == 0)
      {
        currentTarget = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS, 1, UnityEngine.Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS) + shapeshifter.transform.position;

        shapeshifter.transform.LookAt(currentTarget);

        shapeshifter.speed = new Vector3(0,0,1);
      }
    }
    else if(distanceFromLoafPoint > 20)
    {
      shapeshifter.transform.LookAt(loafPoint);
      shapeshifter.speed = new Vector3(0,0,1);
    }
    else if(Vector3.Distance(currentTarget, shapeshifter.transform.position) < 1)
    {
      elaspedStopTime = UnityEngine.Random.Range(2.0F, 5.0F);
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

  public bool IsSeen() {
    return shapeshifter.mesh.GetComponent<Renderer>().isVisible;
  }
}
