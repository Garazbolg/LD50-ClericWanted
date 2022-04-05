using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] public Gameplay.Health health;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private UnityEngine.UI.Slider oldValueSlider;
    [SerializeField] private TMPro.TextMeshProUGUI healthtext;
    [SerializeField] private float oldValueSpeed;

    // Update is called once per frame
    void Update()
    {
        if (!health)
        {
            slider.value = 0;
            oldValueSlider.value = 0;
            return;
        }
        slider.value = health.value / health.MaxValue;
        oldValueSlider.value = Mathf.Lerp(oldValueSlider.value, slider.value, oldValueSpeed * Time.deltaTime);
        if (healthtext)
            healthtext.text = $"{health.value}/{health.MaxValue}";
    }
}
