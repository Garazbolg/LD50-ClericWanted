using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Gameplay.Health health;
    [SerializeField] private UnityEngine.UI.Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = health.value / health.MaxValue;
    }
}
