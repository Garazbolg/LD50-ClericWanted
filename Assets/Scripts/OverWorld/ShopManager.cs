using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] items;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].gameObject.SetActive(!WorldMain.boughtItems[i]);
            items[i].Setup();
        }
    }

    public void Buy(int index)
    {
        WorldMain.UpdateBoughtItem(index);
        Setup();
    }
}
