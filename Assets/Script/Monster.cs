using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//public enum monastertype { goblin,slime}

public class Monster : MonoBehaviour
{

    public Transform monster; // ���� ��ǥ
    
    public Vector3[] pathval = new Vector3[5]; // �̵� ��ǥ
    public float speed; // �� �ð��ȿ� �պ�
    public PathType pathtype = PathType.CatmullRom; // �̵� ���
    public PathMode pathmode; // ��� ���
    public int resolution; // �ػ�
    public Color gizmoColor; // �̵� ��� �� ����

    public float fStartTime; // �� �ð� �Ŀ� ����

    // monastertype monasterType;

    void Start()
    {
        gameObject.SetActive(false);
        Invoke("move", fStartTime); //fStartTime�ð� �ڿ� move����
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
            Debug.Log("����");
            Destroy(gameObject);
        }

    }
    //public void Monastertype()
    //{
    //    case MonsterType(monastertype) {

    //    }
    //}
}
