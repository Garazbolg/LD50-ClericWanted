using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_BigSpell : AttackSpell
{
    public int BaseDamage = 10;
    public int DamagePerStack = 8;
    public override void CastOn(GameObject target)
    {
        Damage = BaseDamage;
        var stacks = target.GetComponent<Assassin_PlanStack>();
        if (stacks != null)
            Damage += DamagePerStack * stacks.ConsumeStacks();

        base.CastOn(target);
    }
}
