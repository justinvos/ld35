using UnityEngine;
using System.Collections.Generic;

public class CreatureType {

  public static float DEFAULT_HERD_RADIUS = 20.0F;

  public static Main main;

  public static List<CreatureType> CREATURE_TYPES;

  public static CreatureType GABBIT;
  public static CreatureType LIZARD;
  public static CreatureType BEAR;
  public static CreatureType SQUIRREL;

  static CreatureType() {
    Main main = GameObject.Find("Main").GetComponent<Main>();

    CREATURE_TYPES = new List<CreatureType>();

    GABBIT = new CreatureType("Gabbit", main.gabbit);
    LIZARD = new CreatureType("Lizard", main.lizard);
    BEAR = new CreatureType("Bear", main.bear);
    SQUIRREL = new CreatureType("squirrel", main.squirrel);
  }

  private int id;
  private string label;
  private GameObject prefab;

  private float herdRadius;

  public CreatureType(string label, GameObject prefab) {
    this.label = label;
    this.prefab = prefab;

    this.herdRadius = CreatureType.DEFAULT_HERD_RADIUS;

    CreatureType.CREATURE_TYPES.Add(this);

    id = CreatureType.CREATURE_TYPES.Count - 1;
  }

  public CreatureType SetHerdRadius(float herdRadius) {
    this.herdRadius = herdRadius;
    return this;
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

  public float GetHerdRadius() {
    return herdRadius;
  }
}
