using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBarView : MonoBehaviour
{
    [SerializeField] public Mana health;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private TMPro.TextMeshProUGUI healthtext;

    // Update is called once per frame
    void Update()
    {
        if(!health)
        {
            slider.value = 0;
            return;
        }
        slider.value = health.CurrentMana / health.MaxValue;
        if (healthtext)
            healthtext.text = $"{string.Format("{0:0.0}", health.CurrentMana)}/{health.MaxValue}";
    }
}
