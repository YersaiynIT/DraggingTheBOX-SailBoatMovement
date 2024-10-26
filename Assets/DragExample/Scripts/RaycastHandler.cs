using UnityEngine;

public class RaycastHandler
{
    public IDraggable GetDraggableObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            return hitInfo.collider.GetComponent<IDraggable>();
        }

        return null;
    }
}
