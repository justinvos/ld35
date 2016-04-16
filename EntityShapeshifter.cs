using UnityEngine;

public class EntityShapeshifter : Entity {
  public AIShapeshifter ai;

  public override void Start() {
    base.Start();
    ai = new AIShapeshifter(this, GameObject.Find("player").GetComponent<EntityPlayer>());

    GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.parent = transform;
  }
}
