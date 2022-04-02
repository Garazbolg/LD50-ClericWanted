using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NutritionType { Herbivorous, Carnivorous }

public class Stomach : MonoBehaviour
{
    [SerializeField] private float maxValue = 10;
    
    public NutritionType nutritionType;

    [SerializeField] private float _currentValue = 10;
    public float CurrentValue { get { return _currentValue; } set { _currentValue = Mathf.Clamp(value, 0, maxValue); } }

    public float FillState => CurrentValue / maxValue;
}
