using UnityEngine;

public class EntityShapeshifter : Entity {
  public AIShapeshifter ai;

  public override void Start() {
    base.Start();

    GameObject mesh = GameObject.CreatePrimitive(PrimitiveType.Sphere);

    mesh.transform.parent = transform;
    mesh.transform.localPosition = Vector3.zero;


    ai = new AIShapeshifter(this, GameObject.Find("player").GetComponent<EntityPlayer>());


  }

  void Update()
  {
    base.Update();
    ai.OnUpdate();
  }
}
