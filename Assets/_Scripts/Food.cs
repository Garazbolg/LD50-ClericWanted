using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Food : MonoBehaviour
{
    [SerializeField] private float value = 1;
    [SerializeField] NutritionType nutritionType;

    private void OnTriggerEnter(Collider other)
    {
        Stomach s;
        if(s = other.GetComponent<Stomach>())
        {
            if (s.nutritionType == nutritionType)
            {
                s.CurrentValue += value;
                Destroy(gameObject);
            }
        }
    }
}
