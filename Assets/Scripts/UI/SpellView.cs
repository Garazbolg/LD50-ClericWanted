using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellView : MonoBehaviour
{
    public Spell spell;
    public Image image;
    public Slider cooldownSlider;
    public Color disabledColor;

    public void Start()
    {
        image.sprite = spell.icon;
    }

    private void Update()
    {
        if (spell.CanCast)
        {
            image.color = Color.white;
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
