using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SimpleTextMeshProBehavior : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntData dataObj;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        UpdateWithIntData();
    }

    private void Update()
    {
        UpdateWithIntData();
    }

    public void UpdateWithIntData()
    {
        textObj.text = "Score: " + dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}
