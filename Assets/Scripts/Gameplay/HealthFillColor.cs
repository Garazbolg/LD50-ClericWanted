using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthFillColor : MonoBehaviour
{
    public Image healthFill;
    public Color baseColor;

    private void Start()
    {
        ResetColor();
    }

    public void SetHealthFillColor(Color color)
    {
        healthFill.color = color;
    }

    public void ResetColor()
    {
        healthFill.color = baseColor;
    }
}
