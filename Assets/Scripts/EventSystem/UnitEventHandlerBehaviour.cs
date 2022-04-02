using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitEventSystem
{
    [RequireComponent(typeof(UnitEventManager))]
    public class UnitEventHandlerBehaviour : MonoBehaviour , IUnitEventHandler
    {
        List<UnitEventHandleToken> handles = new List<UnitEventHandleToken>();
        protected UnitEventHandleToken Subscribe<T>(int priority = 0, UnitEventManager.EventHandlingType handlingType = UnitEventManager.EventHandlingType.Listen) where T : UnitEvent
        {
            var token = UnitEventManager.Get(gameObject).AddHandler<T>(this, priority, handlingType);
            handles.Add(token);
            return token;
        }

        protected virtual void OnDestroy()
        {
            foreach (var token in handles)
            {
                token.Unsubscribe();
            }
        }
    }
}
