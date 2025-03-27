using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTransformBehaviour : MonoBehaviour
{

    
    public float direction1 = 0, direction2 = 180;

    // Update is called once per frame
    void Update()
    {
        var xAxis = Input.GetAxis("Horizontal");
        if (xAxis > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if (xAxis < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}