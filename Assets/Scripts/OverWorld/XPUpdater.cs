using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPUpdater : MonoBehaviour
{
    public TMPro.TextMeshProUGUI uGUI;

    private void Update()
    {
        uGUI.text = WorldMain.XP.ToString();
    }
}
