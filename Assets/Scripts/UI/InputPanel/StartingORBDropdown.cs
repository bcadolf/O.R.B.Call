


using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartingORBDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public List<ORBSingle> startingOrbs = new List<ORBSingle>();

    void Start()
    {
        AssignDropdown();
    }

    void AssignDropdown()
    {
        dropdown.ClearOptions();
        startingOrbs.Clear();

        List<string> options = new List<string>();

        foreach (var orb in ORBDatabase.Instance.orbData)
        {
            if (orb.id >= 1 && orb.id <= 3)
            {
                startingOrbs.Add(orb);

                string label = $"O.R.B. ({orb.type}) - {orb.tier}: {orb.shape}";
                options.Add(label);
            }
        }

        dropdown.AddOptions(options);
    }

}