using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPowerupOnTrigger : MonoBehaviour
{
    private Collider otherCollider;
    public void OnTriggerEnter(Collider other)
    {
        otherCollider = other;
        transform.parent = other.transform;
    }

    private void Update()
    {
        if (otherCollider != null)
        {
            transform.position = otherCollider.transform.position;
            transform.RotateAround(transform.position, transform.forward, Time.deltaTime * 150f);
        }
    }

    public void Detatch()
    {
        otherCollider = null;
        transform.parent = null;
    }
}
