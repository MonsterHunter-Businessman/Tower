using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    Vector2 targetPostion;

    public Vector3 mPosition;
    void Update()
    {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ǥ ����

    }

    void OnMouseDrag()
    {
        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    void OnMouseUp()
    {
        transform.position = targetPostion;
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DropArea") {
            targetPostion = col.transform.position;
            //Debug.Log("�浹");
        } 
        else
        {
            targetPostion = new Vector2(-7, -4);
        }
    }
}
