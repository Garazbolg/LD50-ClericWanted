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
    public Color Tint = Color.white;
    public AudioClip audioClip;
    public float audioVolume = .5f;

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
        AudioManager.Instance.PlaySound(audioClip, audioVolume);
    }

    public bool CanCast => enabled && mana.CurrentMana > ManaCost && (Time.time - lastCastTime) > Cooldown;

    public float GetCooldownFill()
    {
        return (Time.time - lastCastTime) / Cooldown;
    }
}