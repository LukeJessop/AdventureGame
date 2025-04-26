using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBrickScript : MonoBehaviour
{
    public float speed = 3f;          // Movement speed
    public float distance = 5f;       // How far left and right it moves

    public Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector3(startPos.x + x, startPos.y, startPos.z);
    }
}
