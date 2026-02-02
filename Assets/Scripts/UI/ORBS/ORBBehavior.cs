

using UnityEngine;

public class ORBBehavior : MonoBehaviour
{
    public bool isEquipped = false;
    public bool isCalled = false;

    [Header("Visual Indicators")]
    public GameObject equippedIndicator;
    public GameObject calledIndicator;

    public void ToggleEquip()
    {
        // remember this seems backwards but isEqquipped is set false first.
        isEquipped = !isEquipped;

        if(equippedIndicator != null)
        {
            equippedIndicator.SetActive(isEquipped);
        }

    }

    public void ToggleCall()
    {
        if (!isEquipped)
        {
            // need to equip first
            return;
        }
        isCalled = !isCalled;

        if (calledIndicator != null) 
        {
            calledIndicator.SetActive(isCalled);
        }
    }

    public void MoveTo(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}