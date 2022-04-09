using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroEnemiesForSecondsBuff : UnitEventSystem.UnitEventHandlerBehaviour, Gameplay.IDeathHandle
{
    public float Duration = 5;

    private void Start()
    {
        GetComponent<TeamMember>().team.AddToTauntList(gameObject);
        StartCoroutine(CO_DestroyAfterDelay());
    }

    public DeathEvent OnDeath(DeathEvent e)
    {
        Destroy(this);
        return e;
    }

    IEnumerator CO_DestroyAfterDelay()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(this);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GetComponent<TeamMember>().team.RemoveFromTauntList(gameObject);
    }
}
