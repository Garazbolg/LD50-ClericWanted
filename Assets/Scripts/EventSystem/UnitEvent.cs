using System.Collections;
using System.Collections.Generic;

namespace UnitEventSystem
{
    public abstract class UnitEvent
    {
        public bool Handled = false;

        public abstract UnitEvent Call(IUnitEventHandler handler);
    }

    public interface IUnitEventHandler
    { }    
}
