using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    public int currentZone = 0;

    public UnityEvent ZoneChanged = new UnityEvent();

    public GameObject[] Zones;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetZone(currentZone);
    }

    public void SetZone(int index)
    {
        HideZone(currentZone);
        currentZone = index;
        ShowZone(currentZone);
    }

    public void ShowZone(int index)
    {
        Zones[index].SetActive(true);
    }

    public void HideZone(int index)
    {
        Zones[index].SetActive(false);
    }
}
