using UnityEngine;

public class EntityShapeshifter : EntityCreature {

  public CreatureType form;

  public override void Start() {

    ai = new AIShapeshifter(main, this, GameObject.Find("player").GetComponent<EntityPlayer>());
    base.Start();
  }

  public override void Update() {
    base.Update();
  }

  public void shapeshift(CreatureType creatureType) {
    form = creatureType;
    Destroy(transform.GetChild(0).gameObject, 0f);

    GameObject go = main.Spawn("shapeshifterMesh", creatureType, Vector3.zero, 0);
    go.transform.parent = gameObject.transform;

    go.transform.localPosition = Vector3.zero;

    go.transform.localRotation = Quaternion.identity;
  }
}
