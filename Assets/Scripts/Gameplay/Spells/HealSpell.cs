using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    [SerializeField] private float healValue;

    public override void CastOn(GameObject target)
    {
        base.CastOn(target);
        UnitEventSystem.UnitEventManager.Get(target).SendEvent<Gameplay.HealEvent>(new Gameplay.HealEvent(healValue));
    }
}
