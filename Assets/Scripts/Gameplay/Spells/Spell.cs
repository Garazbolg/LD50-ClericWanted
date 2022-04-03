using UnityEngine;

[RequireComponent(typeof(Mana))]
public abstract class Spell : MonoBehaviour
{
    public float ManaCost = 0;
    public float Cooldown = 3;
    public Sprite icon;

    public string spellName;
    [TextArea]
    public string spellDescription;

    private float lastCastTime = 0;
    private Mana mana;

    private void Start()
    {
        mana = GetComponent<Mana>();
    }

    public virtual void CastOn(GameObject target)
    {
        lastCastTime = Time.time;
        mana.CurrentMana -= ManaCost;
    }

    public bool CanCast => enabled && mana.CurrentMana > ManaCost && (Time.time - lastCastTime) > Cooldown;

    public float GetCooldownFill()
    {
        return (Time.time - lastCastTime) / Cooldown;
    }
}