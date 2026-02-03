using UnityEngine;
using TMPro;



public class CharacterStatsUIController : MonoBehaviour
{
    public TMP_Text characterNameText;
    public TMP_Text healthText;
    public TMP_Text energyText;

    public void UpdateStats(string characterName ,int health, int energy)
    {
        characterNameText.text = characterName;
        healthText.text = "Health: " + health;
        energyText.text = "Energy: " + energy;
    }

    public void UpdateInventory()
    {
    }
}


