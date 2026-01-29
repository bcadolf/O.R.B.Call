using System;
using System.Collections.Generic;


[Serializable]
public class ORBData
{
    public List<ORBSingle> ORBS;
}

[Serializable]
public class ORBSingle
{
    public int id;
    public string tier;
    public string type;
    public string shape;
    public string description;
    public int activateCost;
    public int price;

    // need to break down subarrays due to unity in classes then pull
    public List<Ability> abilities;
    public List<PassiveAbilities> passiveAbilities;

}

[Serializable]
public class Ability
{
    public string move;
    public int attack;
    public int defense;
    public int bonus;
    public int energyCost;
}

[Serializable]
public class PassiveAbilities
{
    public int attack;
    public int defense;
    public int bonus;
}