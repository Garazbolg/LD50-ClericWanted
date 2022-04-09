using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_PlanStack : MonoBehaviour
{
    public int StackCount = 0;
    public int MaxStack = 6;

    public void AddStack(int number)
    {
        StackCount = Mathf.Min(StackCount + number, MaxStack);
    }

    public int ConsumeStacks()
    {
        Destroy(this);
        return StackCount;
    }
}
