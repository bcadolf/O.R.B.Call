using UnityEngine;
using TMPro;



public class CharacterStatsUIController : MonoBehaviour
{
    public TMP_Text characterNameText;
    public int health;
    public int energy;
    public int healthMax;
    public int energyMax;
    public TMP_Text healthStatsText;
    public TMP_Text energyStatsText;


    public void StartingStats(string characterName ,int startingHealth, int startingEnergy, int startingHealthMax, int startingEnergyMax)
    {
        characterNameText.text = characterName;
        healthMax = startingHealthMax;
        energyMax = startingEnergyMax;
        energy = startingEnergy;
        health = startingHealth;

        healthStatsText.text = $"Health: {health}/{healthMax}";
        energyStatsText.text = $"Energy: {energy}/{energyMax}";
    }

    public void UpdateStats(string? name = null, int? currentHealth = null, int? newHealthMax = null, int? currentEnergy = null, int? newEnergyMax = null)
    {
        characterNameText.text = name ?? characterNameText.text;
        health = currentHealth ?? health;
        healthMax = newHealthMax ?? healthMax;
        energy = currentEnergy ?? energy;
        energyMax = newEnergyMax ?? energyMax;
        healthStatsText.text = $"Health: {health}/{healthMax}";
        energyStatsText.text = $"Energy: {energy}/{energyMax}";
    }
}


