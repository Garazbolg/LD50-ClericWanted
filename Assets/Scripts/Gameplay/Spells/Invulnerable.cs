using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : UnitEventSystem.UnitEventHandlerBehaviour, Gameplay.IDamageHandle
{
    public float Duration = 10;
    public Color HealthColor = Color.yellow;
    public DamageEvent OnDamage(DamageEvent e)
    {
        e.value = 0;
        e.Handled = true;
        return e;
    }

    void Start()
    {
        StartCoroutine(Co_Delay());
        Subscribe<DamageEvent>(0, UnitEventSystem.UnitEventManager.EventHandlingType.Intercept);
        gameObject.GetComponent<HealthFillColor>().SetHealthFillColor(HealthColor);
    }

    IEnumerator Co_Delay()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(this);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        gameObject.GetComponent<HealthFillColor>().ResetColor();
    }
}
