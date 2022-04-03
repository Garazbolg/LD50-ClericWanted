using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassInspector : MonoBehaviour
{
    public static ClassInspector Instance;

    public bool IsInstance = true;

    public GameObject target;

    public HealthBarView hBar;
    public ManaBarView mBar;
    public TMPro.TextMeshProUGUI iname;
    public Image image;
    public SpellDescription spellDescriptionPrefab;
    public Transform spellsTransform;

    public int maxSpells = 2;

    public string[] shortCuts;

    public void Setup(GameObject go)
    {
        hBar.health = go.GetComponent<Gameplay.Health>();
        mBar.health = go.GetComponent<Mana>();
        iname.text = go.name;
        image.sprite = go.GetComponent<CharacterRenderer>().Get();
        foreach (Transform t in spellsTransform)
        {
            Destroy(t.gameObject);
        }
        var sm = go.GetComponent<SpellManager>();
        for (int i = 0; i < maxSpells; i++)
        {
            if(sm.spells.Length > i)
            {
                var sd = Instantiate(spellDescriptionPrefab, spellsTransform);
                sd.Setup(sm.spells[i],shortCuts[i],i);
            }
        }
    }

    private void OnValidate()
    {
        if (target)
            Setup(target);
    }

    private void Awake()
    {
        if(IsInstance)
            Instance = this;
    }
}
