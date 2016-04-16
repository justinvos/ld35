using UnityEngine;

public class EntityGabbit : EntityCreature {

  public override void Start() {
    
    mesh = Instantiate(GameObject.Find("Main").GetComponent<Main>().gabbit);
    ai = new AICreature(this, GameObject.Find("player").GetComponent<EntityPlayer>());

    base.Start();
  }
}
