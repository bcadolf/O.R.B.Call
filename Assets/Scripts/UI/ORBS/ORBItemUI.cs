using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ORBItemUI : MonoBehaviour, IPointerClickHandler
{
    private ORBSingle orbData;
    private ORBBehavior behavior;


    public void Initialize(ORBSingle data)
    {
        orbData = data;
        behavior = GetComponent<ORBBehavior>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ORBPopupUI.Instance.Show(orbData, behavior);
    }

}

