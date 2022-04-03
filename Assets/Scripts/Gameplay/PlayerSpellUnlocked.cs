using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellUnlocked : MonoBehaviour
{
    public Spell[] spells;
    public SpellManager sm;

    private void Awake()
    {
        List<Spell> sp = new List<Spell>();
        for (int i = 0; i < 4; i++)
        {
            if (WorldMain.unlockedSpells[i])
                sp.Add(spells[i]);
        }
        sm.spells = sp.ToArray();
    }
}
