using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    public SimpleFloatData healthData;

    public void ReduceHealth(float amount)
    {
        if ((healthData.value - amount) <= 0)
        {
            healthData.UpdateValue(0);
        }
        else
        {
            healthData.UpdateValue(amount);
        }
    }
}
