using UnityEngine;

public class EntityCreature : Entity {

  public AICreature ai;

  public override void Start() {
    base.Start();

    //GameObject mesh = GameObject.CreatePrimitive(PrimitiveType.Capsule);
    GameObject mesh = Instantiate(GameObject.Find("Main").GetComponent<Main>().gabbit);

    mesh.transform.parent = transform;
    mesh.transform.localPosition = Vector3.zero;


    ai = new AICreature(this, GameObject.Find("player").GetComponent<EntityPlayer>());
  }

  public override void Update()
  {
    base.Update();
    ai.OnUpdate();
  }
}
