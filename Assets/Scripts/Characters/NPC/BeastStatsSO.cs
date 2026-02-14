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