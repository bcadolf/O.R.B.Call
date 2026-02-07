using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Beast/BeastStats")]
public class BeastStatsSO : ScriptableObject
{
   
    public int id;
     public string beastName;
     public string tier;
     //unity assests
    public Sprite image;
    public GameObject prefab; 

    public List<BeastAbility> abilities;
    public List<LootDrop> lootDrops;
}

[System.Serializable]
public class BeastAbility
{
    public string move;
    public int attack;
    public int defense;
    public int bonus;
    public int energyCost;
}

[System.Serializable]
public class LootDrop
{
    public int orbId;
    public float dropPercent;
}