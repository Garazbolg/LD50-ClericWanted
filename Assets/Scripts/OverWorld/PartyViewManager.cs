using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyViewManager : MonoBehaviour
{
    public static PartyViewManager instance;

    public TextManager textManager;

    private void Awake()
    {
        instance = this;
    }

    public void HideAll()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void DisplayText(string text)
    {
        HideAll();
        textManager.gameObject.SetActive(true);
        textManager.DisplayText(text);
    }

    public void DisplayParty()
    {

    }

    public void DisplayShop()
    {

    }
}
