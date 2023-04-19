using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector2 targetPostion;
    void Update()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 저장

        if (Input.GetMouseButton(0))
        {
            gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
        }

        if(Input.GetMouseButtonUp(0))
        {
            transform.position = targetPostion;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DropArea" && col.gameObject.tag == "Tower") {
            targetPostion = col.transform.position;
        } 
        else
        {
            targetPostion = new Vector2(-7, -4);
        }
    }
}
