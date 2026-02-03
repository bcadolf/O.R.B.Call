using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


[System.Serializable]
public class CharacterRuntime
{
    public string characterName;
    public int health;
    public int energy;
    public List<int> invOrbs;


    public CharacterRuntime(CharacterStatsSO model)
    {
        characterName = model.characterName;
        health = model.healthStart;
        energy = model.energyStart;
        invOrbs = new List<int>();

        foreach (var item in model.startingItems) {
            if (int.TryParse(item, out int id)) {
                invOrbs.Add(id);
            }
        };
    }

}