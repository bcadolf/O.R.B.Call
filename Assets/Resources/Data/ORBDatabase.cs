using System.Collections.Generic;
using UnityEngine;

public class ORBDatabase : MonoBehaviour
{
    public static ORBDatabase Instance { get; private set; }
    public List<ORBSingle> orbData;

    private void Awake()
    {
        Instance = this;
        LoadORBS();
    }

    private void LoadORBS()
    {
        TextAsset json = Resources.Load<TextAsset>("Data/ORBS");

        ORBData collection = JsonUtility.FromJson<ORBData>(json.text);

        orbData = collection.ORBS;
    }

    public ORBSingle GetORBById(int id)
    {
        foreach (var orb in orbData)
        {
            if (orb.id == id)
            {
                return orb;
            }
        }
        return null;
    }
}