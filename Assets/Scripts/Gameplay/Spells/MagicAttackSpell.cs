using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttackSpell : Spell
{
    public float Damage;

    public override void CastOn(GameObject target)
    {
        base.CastOn(target);
        UnitEventSystem.UnitEventManager.Get(target).SendEvent<Gameplay.DamageEvent>(new Gameplay.DamageEvent(Damage, Gameplay.DamageTypes.Magical));
    }
}
