using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Vector3 firstPos, endPos;
    public float playerSpeed;

    void Start()
    {
        
    }

    void Update()
    {
    //    transform.Translate(0f, 0f, 5f * Time.deltaTime);
    if(Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
    else
            if(Input.GetMouseButton(0))
        {
            endPos= Input.mousePosition;
            float distance = endPos.x - firstPos.x;
            transform.Translate(distance * Time.deltaTime * playerSpeed, 0, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }
    }
}
