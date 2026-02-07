using System.Collections.Generic;


public class BeastData
{
    public List<BeastSingle> Beasts;
}

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