using UnityEngine;
using TMPro;
using System.Linq;


public class ORBPopupUI : MonoBehaviour
{
    public static ORBPopupUI Instance { get; private set; }

    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text tierText;
    [SerializeField] private TMP_Text typeText;
    [SerializeField] private TMP_Text shapeText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text abilitiesText;
    [SerializeField] private TMP_Text passiveAbilitesText;
    [SerializeField] private TMP_Text callCostText;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }


    public void Show(ORBSingle data)
    {
        
        abilitiesText.text = string.Join("\n\n", data.abilities.Select(ability => 
            $"{ability.move}\nAttack: {ability.attack}   Defense: {ability.defense}   Bonus: {ability.bonus}   Energy Cost: {ability.energyCost}"));
        passiveAbilitesText.text = string.Join("\n\n", data.passiveAbilities.Select(passives => $"Attack: {passives.attack}   Defense: {passives.defense}   Bonus: {passives.bonus}"));

        tierText.text = "Tier: " + data.tier;
        typeText.text = "Type: " + data.type;
        shapeText.text = "Shape: " + data.shape;
        descriptionText.text = data.description;
        callCostText.text = "Call Cost: " + data.activateCost;

        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}