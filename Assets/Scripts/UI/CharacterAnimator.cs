using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : UnitEventSystem.UnitEventHandlerBehaviour , Gameplay.IDamageHandle , Gameplay.IDeathHandle , Gameplay.IHealHandle
{
    public Animator anim;

    private void Awake()
    {
        UnitEventSystem.UnitEventManager.Get(gameObject).AddHandler<DamageEvent>(this);
        UnitEventSystem.UnitEventManager.Get(gameObject).AddHandler<DeathEvent>(this);
        UnitEventSystem.UnitEventManager.Get(gameObject).AddHandler<HealEvent>(this);
    }

    public void PlayHeal()
    {
        anim.SetTrigger("HealTrigger");
    }

    public void PlayHit(float value)
    {
        anim.SetFloat("DamageTaken", value);
        anim.SetTrigger("HitTrigger");
    }

    public void PlayDeath()
    {
        anim.SetTrigger("DeathTrigger");
    }

    DamageEvent IDamageHandle.OnDamage(DamageEvent e)
    {
        PlayHit(e.value/15);
        return e;
    }

    DeathEvent IDeathHandle.OnDeath(DeathEvent e)
    {
        PlayDeath();
        return e;
    }

    HealEvent IHealHandle.OnHeal(HealEvent e)
    {
        PlayHeal();
        return e;
    }
}
