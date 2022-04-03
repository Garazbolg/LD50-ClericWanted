using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public int index;
    public ShopManager ShopManager;
    public int GoldCost;
    public int XPCost;
    public UnityEngine.UI.Button button;
    public GameObject ofuscer;

    public bool CanBuy()
    {
        return WorldMain.Gold >= GoldCost && WorldMain.XP >= XPCost;
    }

    public void Setup()
    {
        button.interactable = CanBuy();
        ofuscer.SetActive(!CanBuy());
    }

    public void Buy()
    {
        if (CanBuy())
        {
            WorldMain.Gold -= GoldCost;
            WorldMain.XP -= XPCost;
            ShopManager.Buy(index);
        }
    }
}
