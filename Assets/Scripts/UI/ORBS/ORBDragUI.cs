using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ORBDragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private RectTransform rectTransform;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;

        canvasGroup.blocksRaycasts = false;

        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {

        Vector2 localPoint; 

        RectTransformUtility.ScreenPointToLocalPointInRectangle( 
            canvas.transform as RectTransform, eventData.position, 
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, 
            out localPoint 
        );

        rectTransform.anchoredPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData) { 

        canvasGroup.blocksRaycasts = true;

        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("ItemDropZone")) 
        { 
            transform.SetParent(eventData.pointerEnter.transform, false); 
        } 
        else 
        { 
            transform.SetParent(originalParent, false);
        }
    }

}