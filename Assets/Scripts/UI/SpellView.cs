using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellView : MonoBehaviour
{
    public Spell spell;
    public Image image;
    public Slider cooldownSlider;
    public Color enabledColor;
    public Color disabledColor;

    public void Init()
    {
        if (spell)
        {
            image.sprite = spell.icon;
            enabledColor = spell.Tint;
            disabledColor = enabledColor;
            disabledColor.a = .5f;
            image.color = enabledColor;
        }
    }

    private void Update()
    {
        if (!spell) return;
        if (spell.CanCast)
        {
            image.color = enabledColor;
            cooldownSlider.gameObject.SetActive(false);
        }
        else
        {
            image.color = disabledColor;
            cooldownSlider.gameObject.SetActive(true);
            cooldownSlider.value = spell.GetCooldownFill();
        }
    }
}
