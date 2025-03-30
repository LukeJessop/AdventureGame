using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaContainerScript : MonoBehaviour
{
    
    public SimpleFloatData staminaData;
    public void ReduceStamina(float amount)
    {
        staminaData.UpdateValue(amount);
    } 
    public void IncreaseStamina(float amount)
    {
        staminaData.UpdateValue(amount);
    }
}
