using UnityEngine;

public class InventoryORBSpawn : MonoBehaviour
{
    public Transform gridParent;
    public GameObject orbPrefab;

    public void PopulateORBs(CharacterRuntime runtime)
    {
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        foreach (int id in runtime.invOrbs)
        {
            ORBSingle orb = ORBDatabase.Instance.GetORBById(id);

            GameObject instance = Instantiate(orbPrefab, gridParent);
            instance.GetComponent<ORBItemUI>().Initialize(orb);
        }
    }

    public void ClearInventory()
    {
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }
    }
}