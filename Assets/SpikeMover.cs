using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    // Update is called once per frame
    public Vector3 rotationPoint;
    public float rotationSpeed;
    void Update()
    {
        transform.RotateAround(rotationPoint, Vector3.forward, Time.deltaTime * rotationSpeed);
    }

    public void TransformSpike()
    {
        if (transform.localScale.x > .5f)
        {
            transform.localScale = new Vector3(.75f,.75f,.75f);
        }
    }
}