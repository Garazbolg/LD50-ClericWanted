using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockNextAttackBuff : UnitEventSystem.UnitEventHandlerBehaviour, Gameplay.IDamageHandle
{
    public DamageEvent OnDamage(DamageEvent e)
    {
        e.Handled = true;
        Destroy(this);
        return e;
    }

    private void Start()
    {
        Subscribe<Gameplay.DamageEvent>(-10, UnitEventSystem.UnitEventManager.EventHandlingType.Intercept);
    }
}
