using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class Health : UnitEventSystem.UnitEventHandlerBehaviour, IDamageHandle, IHealHandle
    {
        public float value;
        public float MaxValue;


        void Start()
        {
            Subscribe<DamageEvent>();
            Subscribe<HealEvent>();
            value = MaxValue;
        }

        DamageEvent IDamageHandle.OnDamage(DamageEvent e)
        {
            value -= e.value;
            if(value <= 0)
            {
                value = 0;
                UnitEventSystem.UnitEventManager.Get(gameObject).SendEvent<DeathEvent>(new DeathEvent());
            }
            return e;
        }

        HealEvent IHealHandle.OnHeal(HealEvent e)
        {
            value = Mathf.Min(value + e.value, MaxValue);
            return e;
        }
    }
}
