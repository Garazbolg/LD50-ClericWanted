using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_SmallSpell : AttackSpell
{
    public override void CastOn(GameObject target)
    {
        base.CastOn(target);

        Assassin_PlanStack stacks;
        stacks = target.GetComponent<Assassin_PlanStack>();
        if(stacks == null)
            stacks = target.AddComponent<Assassin_PlanStack>();
        stacks.AddStack(1);
    }
}
