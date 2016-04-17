using UnityEngine;

public class EntityGabbit : EntityCreature {

  //DEBUG Start

  public Vector3 loafPoint;
  public Vector3 currentTarget;
  public float remainingRestTime;
  public float rotateAngle;
  //DEBUG END

  public override void Start() {

    mesh = Instantiate(main.gabbit);
    ai = new AICreature(main, this, GameObject.Find("player").GetComponent<EntityPlayer>());

    base.Start();
  }

  public override void Update() {
    base.Update();
    //DEBUG Start
    loafPoint = ai.loafPoint;
    currentTarget = ai.currentTarget;
    remainingRestTime = ai.remainingRestTime;
    rotateAngle = ai.rotateAngle;
    //DEBUG END
  }
}
