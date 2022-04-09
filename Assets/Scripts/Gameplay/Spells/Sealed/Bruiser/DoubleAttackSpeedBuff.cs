using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAttackSpeedBuff : MonoBehaviour
{
    public float Duration = 4f;

    private void Start()
    {
        foreach(var spell in GetComponent<SpellManager>().spells)
        {
            if(spell is Bruiser_SmallSpell)
            {
                spell.Cooldown = spell.Cooldown / 2;
                break;
            }
        }
        StartCoroutine(CO_DestroyAfterDelay());
    }

    IEnumerator CO_DestroyAfterDelay()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(this);
    }

    private void OnDestroy()
    {
        foreach (var spell in GetComponent<SpellManager>().spells)
        {
            if (spell is Bruiser_SmallSpell)
            {
                spell.Cooldown = spell.Cooldown * 2;
                break;
            }
        }
    }
}
