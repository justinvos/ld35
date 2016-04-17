using UnityEngine;

public class CreatureType {

  public static Main main;

  public static CreatureType GABBIT;

  static CreatureType() {
    Main main = GameObject.Find("Main").GetComponent<Main>();
    GABBIT = new CreatureType("Gabbit", main.gabbit);
  }

  private string label;
  private GameObject prefab;

  public CreatureType(string label, GameObject prefab) {
    this.label = label;
    this.prefab = prefab;
  }

  public GameObject GetPrefab() {
    return prefab;
  }


  public string GetLabel() {
    return label;
  }
}
