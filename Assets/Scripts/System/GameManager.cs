using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterStatsUIController statsUI;
    public CharacterStatsSO characterModel;
    public CharacterRuntime character;

    void Start()
    {
        // check for saved character
        character = SavePlayerCharacter.Load();

        // make a new one if the player has not saved a previous one
        if (character == null)
        {
            // pulls from the function that uses the SO 
            character = new CharacterRuntime(characterModel);
        }

        statsUI.UpdateStats(character.health, character.energy, string.Join(", ", character.items));


    }

    public void SaveGame()
    {
        SavePlayerCharacter.Save(character);
    }
}
