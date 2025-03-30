using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBehaviorScript : MonoBehaviour
{
    private Image imageObj;
    public SimpleFloatData dataObj;

    private void Start()
    {
        imageObj = GetComponent<Image>();
    }

    public void UpdateWithFloatData()
    {
        imageObj.fillAmount = dataObj.value;
    }
}
