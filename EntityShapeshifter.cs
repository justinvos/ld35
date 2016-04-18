using UnityEngine;

public class EntityShapeshifter : EntityCreature {

  public Alertness alertness;

  public override void Start() {

    ai = new AIShapeshifter(main, this, GameObject.Find("player").GetComponent<EntityPlayer>());
    base.Start();
  }

  public override void Update() {
    base.Update();
  }

  public void shapeshift(CreatureType creatureType) {
    for (int i = 0; i < transform.childCount; i++) {
      Destroy(transform.GetChild(i).gameObject);
    }

    Debug.Log(creatureType.GetLabel());
    GameObject go = main.Spawn("shapeshifterMesh", creatureType, Vector3.zero, 0);
    go.transform.parent = gameObject.transform;

    this.creatureType = creatureType;

    go.transform.localPosition = Vector3.zero;

    go.transform.localRotation = Quaternion.identity;
  }
}
