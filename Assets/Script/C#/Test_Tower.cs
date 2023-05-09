using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Test_Tower : MonoBehaviour
{

    Vector2 targetPostion;

    public bool yeeee;
    public Vector3 mPosition;
    public GameObject range;


    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;

    void Start()
    {
        yeeee = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    

    void Update()
    {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 저장

    }

    void OnMouseDrag()
    {
        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    void OnMouseUp()
    {
        transform.position = targetPostion;
        range.SetActive(yeeee);
        GetComponent<BoxCollider2D>().enabled = !yeeee;
        GetComponent<CircleCollider2D>().enabled = yeeee;
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DropArea") {
            targetPostion = col.transform.position;
            yeeee = true;
            //Debug.Log("충돌");
        } 
        else
        {
            targetPostion = new Vector2(-7, -4);
            yeeee = false;
        }
    }
}

// GetComponent<BoxCollider>().enable = true;
