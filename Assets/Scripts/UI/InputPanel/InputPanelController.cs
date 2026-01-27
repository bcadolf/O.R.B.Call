using UnityEngine;

public class InputPanelController : MonoBehaviour
{
    public Transform container;

    private MonoBehaviour activeModule;

    public MonoBehaviour ShowModule(MonoBehaviour modulePrefab)
    {
        //clear out any currrent/old input modules
        if (activeModule != null)
        {
            Destroy(activeModule.gameObject);
        }

        //start new module
        activeModule = Instantiate(modulePrefab, container);

        return activeModule;
    }

    public void Clear()
    {
        if (activeModule != null)
        {
            Destroy(activeModule.gameObject);
        }
    }

}