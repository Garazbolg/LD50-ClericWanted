using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldMain
{
    public static int Gold;
    public static int XP;

    public static bool[] unlockedSpells;
    public static bool[] boughtItems;
    public static List<CharacterProfile> party;
    public static int MaxPartymembers = 1;

    public static bool isInit = false;

    public static void Init()
    {
        if (isInit)
            return;
        isInit = true;
        Gold = 1050;
        XP = 0;
        unlockedSpells = new bool[4];
        unlockedSpells[0] = true;
        unlockedSpells[1] = false;
        unlockedSpells[2] = false;
        unlockedSpells[3] = false;
        boughtItems = new bool[4];
        MaxPartymembers = 1;
        boughtItems[0] = false;
        boughtItems[1] = false;
        boughtItems[2] = false;
        boughtItems[3] = false;
        party = new List<CharacterProfile>();
    }

    public static void Unlock(int index)
    {
        unlockedSpells[index] = true;
    }
    /*
    public static void Save()
    {
        PlayerPrefs.SetInt("Gold", Gold);
        PlayerPrefs.SetInt("XP", XP);
    }

    public static void Load()
    {

    }*/

    public static void UpdateBoughtItem(int index)
    {
        switch (index)
        {
            case 0:
                unlockedSpells[1] = true;
                boughtItems[0] = true;
                break;
            case 1:
                unlockedSpells[2] = true;
                boughtItems[1] = true;
                break;
            case 2:
                unlockedSpells[3] = true;
                boughtItems[2] = true;
                break;
            case 3:
                MaxPartymembers = Mathf.Min(MaxPartymembers + 1, 3);
                if (MaxPartymembers >= 3)
                    boughtItems[3] = true;
                break;
            default:
                break;
        }
    }
}
