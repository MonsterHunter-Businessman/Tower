using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgarDrop : MonoBehaviour
{
    Vector3 offest;
    public string destinationTag = "DropArea";

    void OnMouseDown()
    {
        offest = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider2D>().enabled = false;
    }
        
    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offest;
    }

    void OnMouseUp()
    {
        
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToViewportPoint(mouseScreenPos);
    }
}
