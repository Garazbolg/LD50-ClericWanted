using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBarView : MonoBehaviour
{
    [SerializeField] public Mana health;
    [SerializeField] private UnityEngine.UI.Slider slider;

    // Update is called once per frame
    void Update()
    {
        if(!health)
        {
            slider.value = 0;
            return;
        }
        slider.value = health.CurrentMana / health.MaxValue;
    }
}
