using System.Collections.Generic;


[System.Serializable]
public class CharacterRuntime
{
    public string characterName;
    public int healthMax;
    public int health;
    public int energyMax;
    public int energy;
    public List<int> invOrbs;


    public CharacterRuntime(CharacterStatsSO model)
    {
        characterName = model.characterName;
        healthMax = model.healthMaxStart;
        energyMax = model.energyMaxStart;
        health = model.healthStart;
        energy = model.energyMaxStart;
        invOrbs = new List<int>();

        foreach (var item in model.startingItems) {
            if (int.TryParse(item, out int id)) {
                invOrbs.Add(id);
            }
        };
    }

}