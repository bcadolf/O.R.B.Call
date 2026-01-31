using UnityEngine;
using TMPro;



public class CharacterStatsUIController : MonoBehaviour
{
    public TMP_Text characterNameText;
    public TMP_Text healthText;
    public TMP_Text energyText;
    public TMP_Text itemsText;

    public void UpdateStats(string characterName ,int health, int energy, string items)
    {
        characterNameText.text = characterName;
        healthText.text = "Health: " + health;
        energyText.text = "Energy: " + energy;
        itemsText.text = "Items: " + items;
    }
}


