using UnityEngine;

[CreateAssetMenu(menuName = "Character/CharacterStats")]
public class CharacterStatsSO : ScriptableObject
{
    public string characterName;
    public int healthStart;
    public int energyStart;
    public string[] startingItems;
}