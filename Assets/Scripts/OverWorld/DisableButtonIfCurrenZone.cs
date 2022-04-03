using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButtonIfCurrenZone : MonoBehaviour
{
    public int zoneID;
    public UnityEngine.UI.Button button;

    private void Start()
    {
        LobbyManager.Instance.ZoneChanged.AddListener(UpdateState);
    }

    private void UpdateState()
    {
        button.interactable = LobbyManager.Instance.currentZone != zoneID;
    }
}
