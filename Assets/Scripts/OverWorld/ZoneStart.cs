using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneStart : MonoBehaviour
{
    [TextArea]
    public string TextOnArrival;
    private void OnEnable()
    {
        PartyViewManager.instance.DisplayText(TextOnArrival);
    }
}
