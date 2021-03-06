using UnityEngine;

public class EntityCreature : Entity {

  public AICreature ai;
  public EntityHerd herd;

  public CreatureType creatureType;

  public Vector3 loafPoint;

  //DEBUG Start
  public Vector3 currentTarget;
  public float remainingRestTime;
  public float rotateAngle;
  public string creatureLabel;
  //DEBUG END

  public virtual void Start() {
    //mesh.transform.localPosition = Vector3.zero;

    loafPoint = transform.position;
  }

  public override void Update()
  {
    base.Update();
    ai.OnUpdate();

    //DEBUG Start
    //loafPoint = ai.loafPoint;
    currentTarget = ai.currentTarget;
    remainingRestTime = ai.remainingRestTime;
    rotateAngle = ai.rotateAngle;
    creatureLabel = creatureType.GetLabel();
    //DEBUG END
  }
}
