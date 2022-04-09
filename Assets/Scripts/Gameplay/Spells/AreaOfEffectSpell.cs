using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectSpell : Spell
{
    public override void CastOn(GameObject target)
    {
        foreach (TeamMember tm in target.GetComponent<TeamMember>().team.members)
            SingleTargetCast(tm.gameObject);
        base.CastOn(target);
    }

    protected virtual void SingleTargetCast(GameObject target)
    {

    }
}
