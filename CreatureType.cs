using UnityEngine;
using System.Collections.Generic;

public class CreatureType {

  public static Main main;

  public static List<CreatureType> CREATURE_TYPES;

  public static CreatureType GABBIT;
  public static CreatureType LIZARD;
  public static CreatureType BEAR;

  static CreatureType() {
    Main main = GameObject.Find("Main").GetComponent<Main>();

    CREATURE_TYPES = new List<CreatureType>();

    GABBIT = new CreatureType("Gabbit", main.gabbit);
    LIZARD = new CreatureType("Lizard", main.lizard);
    BEAR = new CreatureType("Bear", main.bear);
  }

  private int id;
  private string label;
  private GameObject prefab;

  public CreatureType(string label, GameObject prefab) {
    this.label = label;
    this.prefab = prefab;

    CreatureType.CREATURE_TYPES.Add(this);

    id = CreatureType.CREATURE_TYPES.Count - 1;
  }

  public int GetId() {
    return id;
  }

  public GameObject GetPrefab() {
    return prefab;
  }

  public string GetLabel() {
    return label;
  }
}
