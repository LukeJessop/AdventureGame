using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
}
