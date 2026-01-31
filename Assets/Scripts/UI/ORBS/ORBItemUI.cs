using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ORBItemUI : MonoBehaviour, IPointerClickHandler // IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private ORBSingle orbData;


    public void Initialize(ORBSingle data)
    {
        orbData = data;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ORB CLICKED: " + orbData?.id);
        ORBPopupUI.Instance.Show(orbData);
    }

    public void ClosePopup()
    {
        ORBPopupUI.Instance.Hide();
    }



    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private RectTransform rectTransform;

    // void Awake()
    // {
    //     canvas = GetComponentInParent<Canvas>();
    //     canvasGroup = gameObject.AddComponent<CanvasGroup>();
    //     rectTransform = GetComponent<RectTransform>();
    // }

    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     originalParent = transform.parent;

    //     canvasGroup.blocksRaycasts = false;

    //     transform.SetParent(canvas.transform);
    // }

    // public void OnDrag(PointerEventData eventData)
    // {

    //     Vector2 localPoint; 

    //     RectTransformUtility.ScreenPointToLocalPointInRectangle( 
    //         canvas.transform as RectTransform, eventData.position, 
    //         canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, 
    //         out localPoint 
    //     );

    //     rectTransform.anchoredPosition = localPoint;
    // }

    // public void OnEndDrag(PointerEventData eventData) { 

    //     canvasGroup.blocksRaycasts = true;

    //     if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("ItemDropZone")) 
    //     { 
    //         transform.SetParent(eventData.pointerEnter.transform, false); 
    //     } 
    //     else 
    //     { 
    //         transform.SetParent(originalParent, false);
    //     }
    // }

}

