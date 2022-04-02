using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class Health : MonoBehaviour, IDamageHandle
    {
        public float value;
        public float MaxValue;

        private UnitEventSystem.EventHandlerToken<DamageEvent> damageToken;

        void Start()
        {
            damageToken = new UnitEventSystem.EventHandlerToken<DamageEvent>(this, gameObject);
            damageToken.Subscribe();
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
    }
}
