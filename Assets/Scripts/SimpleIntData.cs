using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleIntData : MonoBehaviour
{
    public int value;

    public void UpdateValue(int amount)
    {
        Debug.Log(value);
        Debug.Log(amount);
        value += amount;
    }

    public void SetValue(int amount)
    {
        value = amount;
    }
}
