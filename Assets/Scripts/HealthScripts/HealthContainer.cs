using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthContainer : MonoBehaviour
{
    public SimpleFloatData healthData;
    public GameObject player;

    public void Start()
    {
        healthData.value = 1f;
    }

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

        if (healthData.value <= 0)
        {
            
            SceneManager.LoadScene(0);
        }
    }
}
