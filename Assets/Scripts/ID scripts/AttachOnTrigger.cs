using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttachOnTrigger : MonoBehaviour
{
    public Id idToAttach;
    private int counter = 1;
    public void OnTriggerEnter(Collider other)
    {
        transform.parent = other.transform;
        if (counter == 1)
        {
            other.AddComponent<SimpleIdBehavior>();
            var idComponent = other.GetComponent<SimpleIdBehavior>();
            idComponent.id = idToAttach;
            counter--;
        }
    }

    public void Detatch(Collider other)
    {
        transform.parent = null;
        var idComponent = other.GetComponent<SimpleIdBehavior>();
        Destroy(idComponent);
        counter++;
    }
}
