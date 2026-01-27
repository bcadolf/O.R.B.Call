using UnityEngine;
using TMPro;
using System.Diagnostics.Contracts;



public class CharacterStatsUIController : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text energyText;
    public TMP_Text itemsText;

    public void UpdateStats(int health, int energy, string items)
    {
        healthText.text = "Health: " + health;
        energyText.text = "Energy: " + energy;
        itemsText.text = "Items: " + items;
    }
}


