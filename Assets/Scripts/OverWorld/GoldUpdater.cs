using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldUpdater : MonoBehaviour
{
    public TMPro.TextMeshProUGUI uGUI;

    private void Update()
    {
        uGUI.text = WorldMain.Gold.ToString();
    }
}
