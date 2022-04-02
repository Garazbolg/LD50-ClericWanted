using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ManaBarView : MonoBehaviour
{
    [SerializeField] private Mana health;
    [SerializeField] private UnityEngine.UI.Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = health.CurrentMana / health.MaxValue;
    }
}
