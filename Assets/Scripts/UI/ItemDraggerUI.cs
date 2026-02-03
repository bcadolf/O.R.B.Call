using UnityEngine.EventSystems;
using UnityEngine;

public class ItemDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private RectTransform rectTransform;
    private Vector2 offset;
    public CharacterRuntime characterRuntime;



    void Awake()
    {
        characterRuntime = GameManager.Instance.character;
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

        if (target != null && target.CompareTag("Inventory") || target.CompareTag("GeneralDrop")) 
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
                //  no Content child exists, just parent to the target
                transform.SetParent(target.transform, false); 
            }
            UpdateOrbLocation(target);
            } 
            else 
            { 
                // go back to box if wrong drop zone
                transform.SetParent(originalParent, false);
                UpdateOrbLocation(originalParent.gameObject);
            } 
    }

    private void UpdateOrbLocation(GameObject dropTarget)
    {
        ORBItemUI orbUI = GetComponent<ORBItemUI>();
        int orbId = orbUI.orbData.id;

        if (dropTarget.CompareTag("Inventory"))
        {
            if (!characterRuntime.invOrbs.Contains(orbId))
            {
                characterRuntime.invOrbs.Add(orbId);
            }
        }
        else if (dropTarget.CompareTag("GeneralDrop"))
        {
            if (characterRuntime.invOrbs.Contains(orbId)) 
            {
                characterRuntime.invOrbs.Remove(orbId);
            }
        }
        
    }
}
