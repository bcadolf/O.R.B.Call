using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Player character ui models and data
    public CharacterStatsSO characterModel;
    public CharacterRuntime character;
    public CreatePCUI createPCPrefab;


    // ui panel controllers
    public InputPanelController inputPanel;
    public CharacterStatsUIController statsUI;

    // system function
    public InventoryORBSpawn inventoryORBSpawn;

    void Awake() {
        Instance = this;
    }

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
        ui.Initialize((name, orbID) =>
        {
            CreateNewPC(name, orbID);
        });
    }

    void CreateNewPC(string name, int orbId)
    {
        // use SO to build runtime
        character = new CharacterRuntime(characterModel);

        character.characterName = name;
        character.invOrbs.Add(orbId);

        SaveGame();

        InitializeGame();
    }

    void InitializeGame()
    {
        inputPanel.Clear();

        statsUI.StartingStats(
            character.characterName,
            character.health,
            character.energy,
            character.healthMax,
            character.energyMax
        );

        inventoryORBSpawn.PopulateORBs(character);

    }

    public void DeleteCharacter()
    {
        DeletePlayerCharacter.Delete();
        character = null;
        statsUI.UpdateStats("",0,0,0,0);
        inventoryORBSpawn.ClearInventory();
        StartCharacterCreation();
    }

    public void ClearInputPanel()
    {
        inputPanel.Clear();
    }

}
