using UnityEngine.EventSystems;
using UnityEngine;

public class ItemDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private RectTransform rectTransform;
    private Vector2 offset;


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

        transform.SetParent(canvas.transform, true);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out Vector2 startMousePos 
        );

        offset = rectTransform.anchoredPosition - startMousePos;

    }

    public void OnDrag(PointerEventData eventData)
    {

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle( 
            canvas.transform as RectTransform, 
            eventData.position, 
            canvas.worldCamera, 
            out Vector2 localPoint) 
        )

        rectTransform.anchoredPosition = localPoint + offset;
    }

    public void OnEndDrag(PointerEventData eventData) { 

        canvasGroup.blocksRaycasts = true;

        GameObject target = eventData.pointerEnter;

        if (target != null && target.CompareTag("ItemDropZone")) 
            { 
            // find content child
            Transform contentTransform = target.transform.Find("Content");

            if (contentTransform != null) 
            {
                // Drop it into the scrollable Content
                transform.SetParent(contentTransform, false); 
            }
            else 
            {
                // Fallback: If no Content child exists, just parent to the target
                transform.SetParent(target.transform, false); 
            }
            } 
            else 
            { 
                // go back to box if wrong drop zone
                transform.SetParent(originalParent, false);
            }
    }
}
