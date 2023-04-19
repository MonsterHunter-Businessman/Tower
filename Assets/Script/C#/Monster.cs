using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Monster : MonoBehaviour
{

    public Transform player;
    public PathType pathsystem = PathType.CatmullRom;
    public PathMode pathmode = PathMode.Ignore;
    public int resulution = 10;
    public Color gizmoColor = Color.red;

    public Vector3[] pathval = new Vector3[0];

    public float speed = 10;

    public float lateTime;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("Move", lateTime);
    }

    void Move()
    {
        gameObject.SetActive(true);
        player.transform.DOPath(pathval, speed, pathsystem, pathmode, resulution, gizmoColor);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }

}
