using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player character ui models and data
    public CharacterStatsSO characterModel;
    public CharacterRuntime character;
    public CreatePCUI createPCPrefab;


    // ui panel controllers
    public InputPanelController inputPanel;
    public CharacterStatsUIController statsUI;


    void Start()
    {
        // check for saved character
        character = SavePlayerCharacter.Load();

        // make a new one if the player has not saved a previous one
        if (character == null)
        {
            // pulls from the function to ask for user input and build from SO
            StartCharacterCreation();
        }
        else
        {
            // loads from save character
            InitializeGame();
        }
    }

    public void SaveGame()
    {
        SavePlayerCharacter.Save(character);
    }

    void StartCharacterCreation()
    {
        // call the inputpanel ui to get user inputs
        var ui = inputPanel.ShowModule(createPCPrefab) as CreatePCUI;

        ui.Initialize((name, item) =>
        {
            CreateNewPC(name, item);
        });
    }

    void CreateNewPC(string name, string item)
    {
        // use SO to build runtime
        character = new CharacterRuntime(characterModel);

        character.characterName = name;
        character.items.Clear();
        character.items.Add(item);

        SaveGame();

        InitializeGame();
    }

    void InitializeGame()
    {
        inputPanel.Clear();

        statsUI.UpdateStats(
            character.characterName,
            character.health,
            character.energy,
            string.Join(", ", character.items)
        );
    }
}
