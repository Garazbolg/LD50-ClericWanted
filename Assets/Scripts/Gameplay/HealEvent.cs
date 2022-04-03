using UnitEventSystem;

namespace Gameplay
{
    public interface IHealHandle : IUnitEventHandler
    {
        HealEvent OnHeal(HealEvent e);
    }

    public class HealEvent : UnitEvent
    {
        public HealEvent(float val)
        {
            value = val;
        }
        public float value;

        public override UnitEvent Call(IUnitEventHandler handler)
        {
            IHealHandle handle = (IHealHandle)handler;
            return handle.OnHeal(this);
        }
    }
}
