using System.Collections.Generic;
using System;

[Serializable]
public class BeastData
{
    public List<BeastSingle> Beasts;
}

[Serializable]
public class BeastSingle
{
    public int id;
    public string image;
    public string name;
    public int health;
    public int energy;
    public List<BeastAbility> abilities;
    public List<LootDrop> lootDrops;
}

[Serializable]
public class BeastAbility
{
    public string move;
    public int attack;
    public int defense;
    public int bonus;
    public int energyCost;
}

[Serializable]
public class LootDrop
{
    public int orbId;
    public float dropPercent;
}