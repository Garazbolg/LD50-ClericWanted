using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldMain
{
    public static int Gold;
    public static int XP;

    public static bool[] unlockedSpells;
    public static List<Item> items;
    public static List<CharacterProfile> party;
    public static int MaxPartymembers = 2;

    public static void Init()
    {
        Gold = 0;
        XP = 0;
        unlockedSpells = new bool[4];
        unlockedSpells[0] = true;
        unlockedSpells[1] = false;
        unlockedSpells[2] = false;
        unlockedSpells[3] = false;
        items = new List<Item>();
        party = new List<CharacterProfile>();
    }

    public static void Unlock(int index)
    {
        unlockedSpells[index] = true;
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("Gold", Gold);
        PlayerPrefs.SetInt("XP", XP);
    }

    public static void Load()
    {

    }
}
