using UnityEngine;

public class ORBGridSpawn : MonoBehaviour
{
    public GameObject ORBPrefab;
    public Transform gridParent;

    void Start()
    {
        SpawnORB();
    }

    void SpawnORB()
    {
        Instantiate(ORBPrefab, gridParent);
    }

}
