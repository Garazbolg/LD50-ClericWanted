using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyDisplay : MonoBehaviour
{
    public TMPro.TextMeshProUGUI[] slots;

    public void Setup()
    {
        foreach (var s in slots)
        {
            s.text = "Empty slot";
            s.fontStyle = TMPro.FontStyles.Italic;
        }
        if (WorldMain.party != null)
        {
            for (int i = 0; i < WorldMain.party.Count; i++)
            {
                slots[i].text = WorldMain.party[i].name;
                slots[i].fontStyle = TMPro.FontStyles.Normal;
            }
        }
    }
}
