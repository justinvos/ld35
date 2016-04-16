using UnityEngine;

public class EntityShapeshifter : EntityCreature {

  public override void Start() {

    mesh = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    ai = new AIShapeshifter(this, GameObject.Find("player").GetComponent<EntityPlayer>());

    base.Start();
  }

  public override void Update()
  {
    base.Update();
  }
}
