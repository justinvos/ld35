using UnityEngine;

public class EntityShapeshifter : EntityCreature {

  public override void Start() {

    ai = new AIShapeshifter(main, this, GameObject.Find("player").GetComponent<EntityPlayer>());

    base.Start();
  }

  public override void Update()
  {
    base.Update();
  }
}
