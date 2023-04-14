using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ǥ ����

        if (Input.GetMouseButton(0))
        {
            gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
        }

    }
}
