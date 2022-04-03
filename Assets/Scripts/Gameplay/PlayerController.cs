using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpellManager))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private SpellManager sm;

    private void Awake()
    {
        Instance = this;
        sm = GetComponent<SpellManager>();
    }

    public void Cast(int index)
    {
        if (sm.CanCast(index) && PlayerTargeter.target)
            sm.Cast(index, PlayerTargeter.target);
    }
}
