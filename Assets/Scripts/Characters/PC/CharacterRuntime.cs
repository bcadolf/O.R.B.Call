using System.Collections.Generic;


[System.Serializable]
public class CharacterRuntime
{
    public string characterName;
    public int health;
    public int energy;
    public List<string> items;

    public CharacterRuntime(CharacterStatsSO model)
    {
        characterName = model.characterName;
        health = model.healthStart;
        energy = model.energyStart;
        items = new List<string>(model.startingItems);
    }

}