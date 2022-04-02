using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitEventSystem
{

    /*
     * This Event system is different in that events can be modified and/or intercepted by any handler
     * 
     * The goal was to be able to have a SpellShield-like handler that would intercept a spellEvent and prevent any handler behind it from having to handle the event while at the same time destroy itself
     * 
     */

    //Event Template

    /*
    
    public interface IDamageHandle : IUnitEventHandler
    {
        DamageEvent OnDamage(DamageEvent e);
    }

    public class DamageEvent : UnitEvent
    {
        public float value;

        public DamageEvent(float value)
        {
            this.value = value;
        }

        public override UnitEvent Call(IUnitEventHandler handler)
        {
            IDamageHandle handle = (IDamageHandle)handler;
            return handle.OnDamage(this);
        }
    }

    */

    //Handler Template : Temporary and small boiler plate

    /*
    
    public class DamageAmplifier : UnitEventSystem.UnitEventHandlerBehaviour, IDamageHandle
    {
        public float multiplier = 1.2f;
        public DamageEvent OnDamage(DamageEvent e)
        {
            e.value = e.value * multiplier;
            return e;
        }

        void Start()
        {
            Subscribe<DamageEvent>(-100, UnitEventSystem.UnitEventManager.EventHandlingType.Modify);
        }
    }

    */

    // Handler template : lifeTime

    /*
    public class DamageNullifier : MonoBehaviour, IDamageHandle
    {
        UnitEventSystem.EventHandlerToken<DamageEvent> eventHandler;
        void Awake()
        {
            eventHandler = new UnitEventSystem.EventHandlerToken<DamageEvent>(this, gameObject, -100, UnitEventSystem.UnitEventManager.EventHandlingType.Modify);
        }
        public DamageEvent OnDamage(DamageEvent e)
        {
            e.Handled = true;
            UnitEventSystem.UnitEventManager.Get(gameObject).SendEvent<MitigatedDamageEvent>(new MitigatedDamageEvent(this,e,e.value));
            return e;
        }

        private void OnEnable()
        {
            eventHandler.Subscribe();
        }

        private void OnDisable()
        {
            eventHandler.Unsubscribe();
        }
    }

    */

}
