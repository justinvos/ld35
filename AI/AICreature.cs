using UnityEngine;

public class AICreature {
  public static float LOAFING_RADIUS = 20;

  protected Main main;
  private EntityCreature creature;
  protected EntityPlayer player;

  public AIHerd herd;

  public Vector3 loafPoint;
  public Vector3 currentTarget;
  public float remainingRestTime;
  public float rotateAngle;

  private float previousDistance;

  public AICreature(Main main, EntityCreature creature, EntityPlayer player) {
    this.creature = creature;
    this.player = player;

    loafPoint = creature.transform.position;
    currentTarget = creature.transform.position;
  }

  public virtual void OnUpdate() {
    OnLoafUpdate();
  }


  public virtual void OnLoafUpdate() {


    if(remainingRestTime > 0) {
      OnLoafResting();
    } else if(Vector3.Distance(currentTarget, creature.transform.position) < 1) {
      remainingRestTime = Random.Range(2.0F, 5.0F);
      creature.SetResting();

      FindNewTargetWhileLoafing();
    }

  }

  public void OnLoafResting() {

    remainingRestTime = remainingRestTime - Time.deltaTime;

    if(remainingRestTime <= 0) {
      creature.transform.Rotate(new Vector3(0, rotateAngle, 0));
      remainingRestTime = 0;
      creature.speed = new Vector3(0,0,1);
    }
  }

  private void FindNewTargetWhileLoafing() {

    if(herd != null) {
      loafPoint = herd.position;
    }

    currentTarget = new Vector3(Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS, 0, Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS) + loafPoint;

    Vector3 delta = currentTarget - creature.transform.position;

    rotateAngle = Vector3.Angle(creature.transform.forward, delta);

    Vector3 cross = Vector3.Cross(creature.transform.forward, delta);
    if (cross.y < 0)
      rotateAngle *= -1;
  }

  private void Wobble() {

  }

  public void PrintVector3(string label, Vector3 v) {
    Debug.Log(label + "= (" + v.x + ", " + v.y + ", " + v.z + ")");
  }



}
