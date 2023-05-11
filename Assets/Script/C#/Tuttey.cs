using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuttey : MonoBehaviour
{

    public Transform target;

    public Vector3 EAsports;

    public string enemyTag;

    public float Pokemon;

    public Transform partToRotate;

    public float turnSpeed;



    Vector2 targetPostion;

    public bool yes;
    public Vector3 mPosition;
    public GameObject range;


    public int health;







    void Start() {

        yes = false;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        Pokemon = EAsports.x;
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Pokemon) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }

    }

    void Update() {

        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 저장

        if (target == null) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);
        
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, EAsports);
    }


    void OnMouseDrag()
    {
        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    void OnMouseUp()
    {
        transform.position = targetPostion;
        range.SetActive(yes);
        //GetComponent<BoxCollider2D>().enabled = !yes;

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DropArea")
        {
            targetPostion = col.transform.position;
            yes = true;
            //Debug.Log("충돌");
        }
        else
        {
            targetPostion = new Vector2(-14, -7);
            yes = false;
        }

        if (col.gameObject.tag == "Test")
        {
            Debug.Log("타워가 많이 아퍼ㅓㅓㅓ");
            health--;
        }

        if (health <= 0)
        {
            Debug.Log("타워 관리 안해?");
            Debug.Log("진짜 이거임???");
            Destroy(gameObject);
        }

    }



}
