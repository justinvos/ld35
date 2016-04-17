using UnityEngine;

public class EntityCreature : Entity {

  public AICreature ai;
  public AIHerd herd;

  //DEBUG Start

  public Vector3 loafPoint;
  public Vector3 currentTarget;
  public float remainingRestTime;
  public float rotateAngle;
  //DEBUG END

  public virtual void Start() {
    //mesh.transform.localPosition = Vector3.zero;

    ai.herd = herd;
  }

  public void SetHerd(AIHerd herd) {
    this.herd = herd;
  }

  public override void Update()
  {
    base.Update();
    ai.OnUpdate();

    //DEBUG Start
    loafPoint = ai.loafPoint;
    currentTarget = ai.currentTarget;
    remainingRestTime = ai.remainingRestTime;
    rotateAngle = ai.rotateAngle;
    //DEBUG END
  }
}
