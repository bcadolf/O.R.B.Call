

using UnityEngine;

public class ORBBehavior : MonoBehaviour
{
    public bool isEquipped = false;
    public bool isCalled = false;

    public void ToggleEquip()
    {
        isEquipped = !isEquipped;

    }

    public void ToggleCall()
    {
        isCalled = !isCalled;
    }

    public void MoveTo(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}