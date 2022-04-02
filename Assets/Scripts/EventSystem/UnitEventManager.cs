using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitEventSystem
{
    //TODO : Clean this all up !!!
    #region Helper Classes

    // Object that holds who is subscribe to a specific event
    internal class UnitEventResponse
    {
        public List<UnitEventHandle> listeners = new List<UnitEventHandle>();
        public List<UnitEventHandle> modifiers = new List<UnitEventHandle>();
        public List<UnitEventHandle> interceptors = new List<UnitEventHandle>();

        public List<UnitEventHandle> GetList(UnitEventManager.EventHandlingType handlingType)
        {
            switch (handlingType)
            {
                case UnitEventManager.EventHandlingType.Modify:
                    return modifiers;
                case UnitEventManager.EventHandlingType.Intercept:
                    return interceptors;
                case UnitEventManager.EventHandlingType.Listen:
                default:
                    return listeners;
            }
        }
    }

    // Priority strategy
    internal class UnitEventHandle : IComparable
    {
        internal int priority;
        internal IUnitEventHandler handler;
        internal UnitEventHandle(IUnitEventHandler handler, int priority = 0)
        {
            this.handler = handler;
            this.priority = priority;
        }

        public int CompareTo(object obj) // Sort in Descending order as we want to go through it in reverse in case of deletion during the propagation
        {
            var other = (UnitEventHandle)obj;
            return -priority.CompareTo(other.priority);
        }
    }

    // Link between the event manager and the handler. The user can keep a reference to that token to interact with the subscription
    public class UnitEventHandleToken
    {
        internal UnitEventHandle handle;
        internal List<UnitEventHandle> handleList;

        public void Subscribe()
        {
            handleList.Add(handle);
        }

        public void Unsubscribe()
        {
            handleList.Remove(handle);
        }
    }

    // Wrapper over UnitEventHandleToken for initialization
    public class EventHandlerToken<T> where T : UnitEvent
    {
        UnitEventHandleToken handleToken;
        public EventHandlerToken(IUnitEventHandler handler, GameObject go, int priority = 0, UnitEventManager.EventHandlingType handlingType = UnitEventManager.EventHandlingType.Listen)
        {
            handleToken = UnitEventManager.Get(go).GetHandleToken<T>(handler, priority, handlingType);
        }

        public void Subscribe()
        {
            handleToken.Subscribe();
        }
        public void Unsubscribe()
        {
            handleToken.Unsubscribe();
        }
    }

    #endregion

    public class UnitEventManager : MonoBehaviour
    {
        public enum EventHandlingType { Listen, Modify, Intercept }

        private Dictionary<System.Type, UnitEventResponse> handlers = new Dictionary<System.Type, UnitEventResponse>();

        public void SendEvent<T>(T e) where T : UnitEvent
        {
            var ehl = GetResponse<T>();
            UnitEvent ev = e;
            ev = Propagate(ehl.GetList(EventHandlingType.Intercept), ev);
            if (ev.Handled) return;
            ev = Propagate(ehl.GetList(EventHandlingType.Modify), ev);
            if (ev.Handled) return;
            ev = Propagate(ehl.GetList(EventHandlingType.Listen), ev);
        }

        private UnitEvent Propagate(List<UnitEventHandle> list, UnitEvent e)
        {
            UnitEvent ev = e;
            list.Sort(); // TODO : Use sorted list so that remove is faster, and we don't have to sort it before every use
            foreach (UnitEventHandle eh in list.AsReverse()) // Can we unsubscribe during the propagation (With AsReverse yes)
            {
                ev = ev.Call(eh.handler);
                if (ev.Handled)
                    return ev;
            }
            return ev;
        }

        #region Getters
        public static UnitEventManager Get(GameObject target)
        {
            return target.GetComponent<UnitEventManager>();
        }


        private UnitEventResponse GetResponse<T>()
        {
            UnitEventResponse list;
            if (!handlers.ContainsKey(typeof(T)))
            {
                list = new UnitEventResponse();
                handlers.Add(typeof(T), list);
            }
            else
            {
                handlers.TryGetValue(typeof(T), out list);
            }
            return list;
        }
        #endregion

        #region Subscription Handling

        public UnitEventHandleToken AddHandler<T>(IUnitEventHandler handler, int priority = 0, EventHandlingType handlingType = EventHandlingType.Listen) where T : UnitEvent
        {
            var token = GetHandleToken<T>(handler, priority, handlingType);
            token.Subscribe();
            return token;
        }

        public UnitEventHandleToken GetHandleToken<T>(IUnitEventHandler handler, int priority = 0, EventHandlingType handlingType = EventHandlingType.Listen) where T : UnitEvent
        {
            UnitEventHandleToken token = new UnitEventHandleToken();
            token.handle = new UnitEventHandle(handler, priority);
            token.handleList = GetResponse<T>().GetList(handlingType);
            return token;
        }
        #endregion
    }
}
