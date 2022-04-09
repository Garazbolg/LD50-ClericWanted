using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBuffSpell : Spell
{
    public string BuffComponent;
    public override void CastOn(GameObject target)
    {
        base.CastOn(target);
        gameObject.AddComponent(Type.GetType(BuffComponent));
    }
}
