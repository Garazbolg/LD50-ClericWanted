using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float _currentValue;
    public float MaxValue;

    public float CurrentMana { get { return _currentValue; } set { _currentValue = Mathf.Clamp(value, 0, MaxValue); } }
}
