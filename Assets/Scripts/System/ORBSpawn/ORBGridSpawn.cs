using Unity.VisualScripting;
using UnityEngine;

public class ORBGridSpawn : MonoBehaviour
{
    public GameObject basicORBPrefab;
    public Transform gridParent;

    void Start()
    {
        SpawnORBs();
    }

    void SpawnORBs()
    {
        foreach (var orb in ORBDatabase.Instance.orbData)
        {
            // this will select the prefab based on orb tier currently basic but will have more later
            GameObject prefabMatch = GetPrefabByTier(orb.tier);

            GameObject orbInstance = Instantiate(prefabMatch, gridParent);

            // add data to orb prefab on scene
            ORBItemUI ui = orbInstance.GetComponent<ORBItemUI>();
            
            ui.Initialize(orb);
        }
    }

    GameObject GetPrefabByTier(string tier)
    {
        // add functions when more tiers are ready
        return basicORBPrefab;
    }

}
