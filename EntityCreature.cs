using UnityEngine;

public class EntityCreature : Entity {

  public AICreature ai;
  public GameObject mesh;
  public AIHerd herd;

  public override void Start() {
    base.Start();

    mesh.transform.parent = transform;
    mesh.transform.localPosition = Vector3.zero;

    ai.herd = herd;
  }

  public void SetHerd(AIHerd herd) {
    this.herd = herd;
  }

  public override void Update()
  {
    base.Update();
    ai.OnUpdate();
  }
}
