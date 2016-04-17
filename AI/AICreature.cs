using UnityEngine;

public class AICreature {
  public static float LOAFING_RADIUS = 20;

  private EntityCreature creature;
  private EntityPlayer player;

  public AIHerd herd;

  private Vector3 loafPoint;
  private Vector3 currentTarget;
  private float remainingRestTime;

  public AICreature(EntityCreature creature, EntityPlayer player) {
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
      remainingRestTime = remainingRestTime - Time.deltaTime;

      if(remainingRestTime <= 0) {
        remainingRestTime = 0;

        if(herd != null) {
          loafPoint = herd.position;
        }

        currentTarget = new Vector3(Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS, 1, Random.Range(-1.0f, 1.0f) * LOAFING_RADIUS) + loafPoint;

        creature.transform.LookAt(currentTarget);

        creature.speed = new Vector3(0,0,1);
      }
    } else if(Vector3.Distance(currentTarget, creature.transform.position) < 1) {
      remainingRestTime = Random.Range(2.0F, 5.0F);
      creature.speed = new Vector3(0, 0, 0);
    }
  }

}
