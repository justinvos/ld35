using UnityEngine;

public class AICreature {

  protected Main main;
  private EntityCreature creature;
  protected EntityPlayer player;

  public Vector3 currentTarget;
  public float remainingRestTime;
  public float rotateAngle;

  private float previousDistance;

  public AICreature(Main main, EntityCreature creature, EntityPlayer player) {
    this.main = main;
    this.creature = creature;
    this.player = player;


    currentTarget = creature.transform.position;
  }

  public virtual void OnUpdate() {
    MovementUpdate();
  }

  public virtual void OnLoafUpdate() {
    MovementUpdate();
  }

  public virtual void MovementUpdate() {


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
    if (remainingRestTime < 1 && remainingRestTime > 0) {
      creature.transform.Rotate(new Vector3(0, rotateAngle * Time.deltaTime, 0));

    } else if (remainingRestTime <= 0) {
      remainingRestTime = 0;
      creature.speed = new Vector3(0,0,1);
    }
  }

  public void FindNewTargetWhileLoafing() {

    if(creature.herd != null) {
      creature.loafPoint = creature.herd.transform.position;
    }

    currentTarget = new Vector3(Random.Range(-1.0f, 1.0f) * creature.creatureType.GetHerdRadius(), 0, Random.Range(-1.0f, 1.0f) * creature.creatureType.GetHerdRadius()) + creature.loafPoint;

    Vector3 delta = currentTarget - creature.transform.position;

    rotateAngle = Vector3.Angle(creature.transform.forward, delta);

    Vector3 cross = Vector3.Cross(creature.transform.forward, delta);
    if (cross.y < 0)
      rotateAngle *= -1;
  }

  public void PrintVector3(string label, Vector3 v) {
    Debug.Log(label + "= (" + v.x + ", " + v.y + ", " + v.z + ")");
  }



}
