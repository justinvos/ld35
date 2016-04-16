using UnityEngine;

public class EntityShapeshifter : Entity {
  public AIShapeshifter ai;
  public GameObject mesh;

  public override void Start() {
    base.Start();

    mesh = GameObject.CreatePrimitive(PrimitiveType.Sphere);

    mesh.transform.parent = transform;
    mesh.transform.localPosition = Vector3.zero;


    ai = new AIShapeshifter(this, GameObject.Find("player").GetComponent<EntityPlayer>());


  }

  public override void Update()
  {
    base.Update();
    ai.OnUpdate();
  }
}
