using Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mana))]
public class SpellManager : UnitEventSystem.UnitEventHandlerBehaviour, Gameplay.IDeathHandle
{
    public Spell[] spells;

    private Mana mana;

    private void Awake()
    {
        mana = GetComponent<Mana>();
    }

    private void Start()
    {
        Subscribe<Gameplay.DeathEvent>();
    }

    public bool CanCast(int index)
    {
        if (!this.enabled) return false;
        if (spells.Length <= index) throw new System.Exception("Invalid Index for spell. Length:" + spells.Length + " index:" + index);
        return spells[index].CanCast;
    }

    public void Cast(int index, GameObject target)
    {
        spells[index].CastOn(target);
    }

    public DeathEvent OnDeath(DeathEvent e)
    {
        enabled = false;
        foreach (var spell in spells)
        {
            spell.enabled = false;
        }
        return e;
    }
}
