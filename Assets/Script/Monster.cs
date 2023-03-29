using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//public enum monastertype { goblin,slime}

public class Monster : MonoBehaviour
{

    public Transform monster; // 몬스터 좌표
    
    public Vector3[] pathval = new Vector3[5]; // 이동 좌표
    public float speed; // 이 시간안에 왕복
    public PathType pathtype = PathType.CatmullRom; // 이동 방식
    public PathMode pathmode; // 경로 모드
    public int resolution; // 해상도
    public Color gizmoColor; // 이동 경로 색 지정

    public float fStartTime; // 이 시간 후에 시작

    // monastertype monasterType;

    void Start()
    {
        gameObject.SetActive(false);
        Invoke("move", fStartTime); //fStartTime시간 뒤에 move실행
    }

    void move()
    {
        gameObject.SetActive(true);
        monster.transform.DOPath(pathval, speed, pathtype, pathmode, resolution, gizmoColor);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "END")
        {
            Debug.Log("뒤짐");
            Destroy(gameObject);
        }

    }
    //public void Monastertype()
    //{
    //    case MonsterType(monastertype) {

    //    }
    //}
}
