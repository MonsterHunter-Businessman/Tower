using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 저장

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
        }
    }
}
