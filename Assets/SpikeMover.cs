using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(-0.5f,0.3f,0), Vector3.forward, Time.deltaTime * 10f);
    }
}
