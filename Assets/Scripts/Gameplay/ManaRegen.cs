using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mana))]
public class ManaRegen : UnitEventSystem.UnitEventHandlerBehaviour, Gameplay.IDeathHandle
{
    private Mana mana;
    [SerializeField] private float regenSpeed = 2;

    public DeathEvent OnDeath(DeathEvent e)
    {
        Destroy(this);
        return e;
    }

    private void Awake()
    {
        mana = GetComponent<Mana>();
    }

    private void Start()
    {
        Subscribe<DeathEvent>();
    }

    private void Update()
    {
        mana.CurrentMana += regenSpeed * Time.deltaTime;
    }
}
