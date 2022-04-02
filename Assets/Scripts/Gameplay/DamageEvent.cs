using UnitEventSystem;

namespace Gameplay
{
    public interface IDamageHandle : IUnitEventHandler
    {
        DamageEvent OnDamage(DamageEvent e);
    }

    public class DamageEvent : UnitEvent
    {
        public float value;
        public DamageTypes type;

        public DamageEvent(float value, DamageTypes type)
        {
            this.value = value;
            this.type = type;
        }

        public override UnitEvent Call(IUnitEventHandler handler)
        {
            IDamageHandle handle = (IDamageHandle)handler;
            return handle.OnDamage(this);
        }
    }


    public enum DamageTypes { Physical, Magical, True }
}
