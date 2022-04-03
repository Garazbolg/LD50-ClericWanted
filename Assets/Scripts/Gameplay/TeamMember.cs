using Gameplay;
using UnityEngine;

public class TeamMember : UnitEventSystem.UnitEventHandlerBehaviour, Gameplay.IDeathHandle
{
    public TeamManager team;
    public float aggroStat;

    private void Start()
    {
        Subscribe<DeathEvent>();
    }

    public GameObject GetTarget()
    {
        if (!team.targetTeam) return null;
        return team.targetTeam.GetAggroTarget();
    }

    public DeathEvent OnDeath(DeathEvent e)
    {
        team.Remove(this);
        return e;
    }
}