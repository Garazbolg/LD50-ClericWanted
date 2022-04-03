using UnitEventSystem;

namespace Gameplay
{
    public interface IDeathHandle : IUnitEventHandler
    {
        DeathEvent OnDeath(DeathEvent e);
    }

    public class DeathEvent : UnitEvent
    {

        public override UnitEvent Call(IUnitEventHandler handler)
        {
            IDeathHandle handle = (IDeathHandle)handler;
            return handle.OnDeath(this);
        }
    }

}
