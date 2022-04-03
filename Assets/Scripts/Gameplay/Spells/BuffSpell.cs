using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BuffSpell : Spell
{
    public string BuffComponent;
    public override void CastOn(GameObject target)
    {
        base.CastOn(target);
        target.AddComponent(Type.GetType(BuffComponent));
    }
}
