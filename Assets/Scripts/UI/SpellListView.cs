using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellListView : MonoBehaviour
{
    [SerializeField] private SpellManager sm;
    [SerializeField] private SpellView spellViewPrefab;

    private void Start()
    {
        for (int i = 0; i < sm.spells.Length; i++)
        {
            var sv = Instantiate(spellViewPrefab, transform);
            sv.spell = sm.spells[i];
            sv.Init();
        }
    }
}
