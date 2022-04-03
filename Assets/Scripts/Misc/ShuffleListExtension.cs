using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShuffleListExtension
{
    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Swap(i, Random.Range(0, list.Count), ref list);
        }
    }

    private static void Swap<T>(int a, int b,ref List<T> list)
    {
        var tmp = list[a];
        list[a] = list[b];
        list[b] = tmp;
    }
}