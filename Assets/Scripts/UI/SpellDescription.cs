using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDescription : MonoBehaviour
{
    public Image sprite;
    public TMPro.TextMeshProUGUI title;
    public TMPro.TextMeshProUGUI description;
    public TMPro.TextMeshProUGUI manaCost;
    public TMPro.TextMeshProUGUI cooldown;
    public TMPro.TextMeshProUGUI shortcut;
    public Slider slider;
    public Image disable;
    public Color enabledColor;
    public Color disabledColor;

    private Spell spell;
    public void Setup(Spell spelly, string shortcutS = "")
    {
        spell = spelly;
        if(!spell)
        {
            Destroy(gameObject);
        }
        sprite.sprite = spell.icon;
        sprite.color = spell.Tint;
        title.text = spell.spellName;
        description.text = spell.spellDescription;
        manaCost.text = spell.ManaCost.ToString();
        cooldown.text = "" + string.Format("{0:0.0}", spell.Cooldown) + "s";
        if (shortcut)
            shortcut.text = shortcutS;
        disable.color = enabledColor;
    }

    private void Update()
    {
        if(spell && slider)
        {
            slider.value = 1-spell.GetCooldownFill();
        }
        if(spell)
            disable.color = spell.CanCast ? enabledColor : disabledColor;
    }
}
