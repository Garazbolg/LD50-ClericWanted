using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpellManager))]
[RequireComponent(typeof(TeamMember))]
public class AIController : MonoBehaviour
{
    private SpellManager spellManager;
    private TeamMember tm;

    private void Awake()
    {
        spellManager = GetComponent<SpellManager>();
        tm = GetComponent<TeamMember>();
    }

    private void Update()
    {
        var target = tm.GetTarget();
        if (target == null) return;
        if (spellManager.CanCast(1))
        {
            spellManager.Cast(1,target);
        }
        else if(spellManager.CanCast(0))
        {
            spellManager.Cast(0, target);
        }
    }
}
