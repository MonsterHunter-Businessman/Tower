using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{

    public Vector3 mPosition;

    // Update is called once per frame
    void Update() {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 저장
        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    }
}
