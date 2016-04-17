using UnityEngine;

public class AIHerd {

  private EntityHerd herd;

  private Vector3 target;

  public AIHerd(EntityHerd herd) {
    this.herd = herd;

    target = herd.transform.position;
  }

  public void OnUpdate() {

    if(Vector3.Distance(herd.transform.position, target) < 1) {
      target = new Vector3(herd.transform.position.x + 50 * Random.Range(1, 3), 0, herd.transform.position.y + 50 * Random.Range(1, 3));
    }

    herd.transform.Translate(0.2F * Vector3.forward * Time.deltaTime);
  }
}
