using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttachOnTrigger : MonoBehaviour
{
    public Id idToAttach;
    public void OnTriggerEnter(Collider other)
    {
        transform.parent = other.transform;
        other.AddComponent<SimpleIdBehavior>();
        var idComponent = other.GetComponent<SimpleIdBehavior>();
        idComponent.id = idToAttach;
    }

    public void OnTriggerExit(Collider other)
    {
        transform.parent = null;
    }
}
