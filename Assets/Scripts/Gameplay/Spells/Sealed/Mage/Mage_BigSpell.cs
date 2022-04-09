using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Mage_BigSpell : AreaOfEffectSpell
{
    public float Damage;

    protected override void SingleTargetCast(GameObject target)
    {
        base.SingleTargetCast(target);
        UnitEventSystem.UnitEventManager.Get(target).SendEvent<Gameplay.DamageEvent>(new Gameplay.DamageEvent(Damage, Gameplay.DamageTypes.Magical));
    }
}