using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehavior : MonoBehaviour
{
    public Id id;
    public UnityEvent matchEvent, noMatchEvent;

    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<SimpleIdBehavior>();

        if (otherID.id == id)
        {
            matchEvent.Invoke();
            Debug.Log("matched! " + id);
        }
        else
        {
            noMatchEvent.Invoke();
            Debug.Log("no match! " + id);
        }
    }
}