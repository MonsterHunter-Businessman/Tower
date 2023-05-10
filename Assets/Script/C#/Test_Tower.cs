using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Test_Tower : MonoBehaviour
{

    Vector2 targetPostion;

    public bool yes;
    public Vector3 mPosition;
    public GameObject range;


    BoxCollider2D boxCollider;

    public int health;

    void Start() {
        yes = false;
    }

    

    void Update() {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ǥ ����
    }

    void OnMouseDrag() {
        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    void OnMouseUp() {
        transform.position = targetPostion;
        range.SetActive(yes);
        //GetComponent<BoxCollider2D>().enabled = !yes;
        
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "DropArea") {
            targetPostion = col.transform.position;
            targetPostion.y += 0.4f;
            yes = true;
            //Debug.Log("�浹");
        } else {
            targetPostion = new Vector2(-14, -7);
            yes = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {

        //Debug.Log("�浹�� �ϳ�?");

        if (col.gameObject.tag == "Test") {
            Debug.Log("Ÿ���� ���� ���ۤää�");
            health--;
        }

        if (health <= 0) {
            Debug.Log("Ÿ�� ���� ����?");
            Debug.Log("��¥ �̰���???");
            Destroy(gameObject);
        }

    }
}

// GetComponent<BoxCollider>().enable = true;
