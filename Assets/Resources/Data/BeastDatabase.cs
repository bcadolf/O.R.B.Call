using System.Collections.Generic;
using UnityEngine;


public class BeastDatabase : MonoBehaviour
{
    public static BeastDatabase Instance { get; private set; }

    public List<BeastSingle> beastData;

    private void Awake()
    {
        Instance = this;
        LoadBeasts();
    }

    private void LoadBeasts()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/Beasts");

        BeastData collection = JsonUtility.FromJson<BeastData>(json.text);

        beastData = collection.Beasts;
    }

    public BeastSingle GetBeastById(int id)
    {
        foreach (var beast in beastData)
        {
            if (beast.id == id)
            {
                return beast;
            }
        }
        return null;
    }
}