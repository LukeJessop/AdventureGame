using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    // Update is called once per frame
    public GameObject rotateAroundObject;
    public float rotationSpeed;
    void Update()
    {
        transform.RotateAround(rotateAroundObject.transform.position, Vector3.forward, Time.deltaTime * rotationSpeed);
    }
}