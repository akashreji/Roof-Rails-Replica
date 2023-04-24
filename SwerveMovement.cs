using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{

    private Transform ball;
    private Vector3 startMousePos, startBallPos;
    private bool moveTheBall;
    [Range(0f, 1f)] public float maxSpeed;
    private float velocity;

    private void Start()
    {
        ball = transform;
        maxSpeed = 0.5f;
    }

    private void Update()
    {
        transform.Translate(0f, 0f, 5f * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            moveTheBall = true;

            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startBallPos = ball.position;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveTheBall = false;
        }

        if (moveTheBall)
        {
            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 MouseNewPos = mouseNewPos - startMousePos;
                Vector3 DesiredBallPos = mouseNewPos - startBallPos;

                ball.position = new Vector3(Mathf.SmoothDamp(ball.position.x, DesiredBallPos.x, ref velocity, smoothTime: maxSpeed), ball.position.y, ball.position.z);

            }
        }
    }

}