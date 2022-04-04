using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerGameOver : UnitEventSystem.UnitEventHandlerBehaviour, Gameplay.IDeathHandle
{
    public DeathEvent OnDeath(DeathEvent e)
    {
        GameManager.GameOver();
        return e;
    }

    private void Start()
    {
        Subscribe<Gameplay.DeathEvent>();
    }
}
