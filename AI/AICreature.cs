using UnityEngine;

public class AICreature {

  public static float TURNING_TIME = 1F;

  protected Main main;
  private EntityCreature creature;
  protected EntityPlayer player;

  public Vector3 currentTarget;
  public float remainingRestTime;
  public float rotateAngle;

  private float previousDistance;

  private bool isTurning;

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

    creature.angularVelocity = 0;
    creature.speed = Vector3.zero;

    float distanceFromPlayer = Vector3.Distance(player.transform.position, creature.transform.position);
    Vector3 displacementToPlayer = player.transform.position - creature.transform.position;

    RaycastHit hit;

    if(Physics.Raycast(creature.transform.position, creature.transform.forward, out hit, 3)) {
      currentTarget = FindNewTarget();

      SetResting();
    }


    if(distanceFromPlayer <= 10) {
      if(distanceFromPlayer <= 8 && Vector3.Angle(displacementToPlayer, creature.transform.forward) < 90) {

        creature.speed = Vector3.zero;

        creature.angularVelocity = 100 * FindAvoidanceRotation();
        return;
      }
      else {
        creature.speed = Vector3.forward;
        return;
      }
    }

    if(Vector3.Distance(creature.transform.position, currentTarget) < 1) {
      currentTarget = FindNewTarget();

      SetResting();
    } else {
      creature.angularVelocity = FindAngleToTarget();
      creature.speed = Vector3.forward;
    }

    if(IsResting()) {

      creature.speed = Vector3.zero;
      remainingRestTime = remainingRestTime - Time.deltaTime;

      if(remainingRestTime < 1) {
        creature.angularVelocity = FindAngleToTarget();
      }

      return;
    }
  }


  public void SetResting() {
    remainingRestTime = Random.Range(2.0F, 5.0F);
  }

  public bool IsResting() {
    return remainingRestTime > 0;
  }

  public float FindAvoidanceRotation() {
    Vector3 delta = creature.transform.position - player.transform.position;

    Vector3 left = new Vector3(-delta.z, delta.x);
    Vector3 right = new Vector3(delta.z, -delta.x);

    float angle = 0;

    Vector3 creatureForward = creature.transform.forward;

    if(Vector3.Angle(creatureForward, left) < Vector3.Angle(creatureForward, right)) {
      angle = 1;
    } else {
      angle = -1;
    }

    return angle;
  }

  public float FindAngleToTarget() {
    Vector3 displacementToTarget = currentTarget - creature.transform.position;

    float sign = 1;

    Vector3 cross = Vector3.Cross(creature.transform.forward, displacementToTarget);
    if (cross.y < 0)
      sign *= -1;

    return sign * Vector3.Angle(creature.transform.forward, displacementToTarget);
  }

  public Vector3 FindNewTarget() {
    if(creature.herd != null) {
      creature.loafPoint = creature.herd.transform.position;
    }

    float x = Random.Range(-1.0f, 1.0f) * creature.creatureType.GetHerdRadius();
    float z = Random.Range(-1.0f, 1.0f) * creature.creatureType.GetHerdRadius();

    return new Vector3(x, 1, z) + creature.loafPoint;
  }

  /*
  public virtual void MovementUpdate() {


    if(remainingRestTime > 0) {
      OnLoafResting();
    } else if(Vector3.Distance(currentTarget, creature.transform.position) < 1) {
      remainingRestTime = Random.Range(2.0F, 5.0F);
      creature.SetResting();

      FindNewTargetWhileLoafing();
    }


    bool isAvoidingPlayer = AvoidanceMovement();

    if(!isAvoidingPlayer && remainingRestTime <= 0) {
      creature.speed = new Vector3(0,0,1);
    }

  }*/

  /*
  public void OnLoafResting() {

    remainingRestTime = remainingRestTime - Time.deltaTime;
    if (remainingRestTime < AICreature.TURNING_TIME && remainingRestTime > 0) {
      creature.transform.Rotate(new Vector3(0, rotateAngle * Time.deltaTime, 0));

    } else if (remainingRestTime <= 0) {
      remainingRestTime = 0;
      creature.speed = new Vector3(0,0,1);
    }
  }
*/
  /*public void FindNewTargetWhileLoafing() {

    if(creature.herd != null) {
      creature.loafPoint = creature.herd.transform.position;
    }

    currentTarget = new Vector3(Random.Range(-1.0f, 1.0f) * creature.creatureType.GetHerdRadius(), 0, Random.Range(-1.0f, 1.0f) * creature.creatureType.GetHerdRadius()) + creature.loafPoint;

    Vector3 delta = currentTarget - creature.transform.position;

    rotateAngle = Vector3.Angle(creature.transform.forward, delta);

    Vector3 cross = Vector3.Cross(creature.transform.forward, delta);
    if (cross.y < 0)
      rotateAngle *= -1;
  }*/

  /*

  public bool AvoidanceMovement() {

    if(creature is EntityShapeshifter) {
      return false;
    }
    if(Vector3.Distance(player.transform.position, creature.transform.position) >= 10) {
      return false;
    }
    if(Vector3.Angle(player.transform.position - creature.transform.position, creature.transform.forward) > 90) {
      return false;
    }

    Vector3 delta = creature.transform.position - player.transform.position;



    Vector3 left = new Vector3(-delta.z, delta.x);
    Vector3 right = new Vector3(delta.z, -delta.x);

    float angle = 0;

    Vector3 creatureForward = creature.transform.forward;

    if(Vector3.Angle(creatureForward, left) < Vector3.Angle(creatureForward, right)) {
      angle = 1;
    } else {
      angle = -1;
    }



    creature.transform.Rotate(0, 100 * angle * Time.deltaTime,0);

    creature.speed = Vector3.zero;

    return true;
  }


  */

  public void PrintVector3(string label, Vector3 v) {
    Debug.Log(label + "= (" + v.x + ", " + v.y + ", " + v.z + ")");
  }



}
