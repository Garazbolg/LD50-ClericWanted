using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stomach))]
public class Hunger : MonoBehaviour
{
    [SerializeField] private float hungerSpeed = 1;

    private Stomach stomach;

    private void Awake()
    {
        stomach = GetComponent<Stomach>();
    }

    private void Update()
    {
        stomach.CurrentValue -= hungerSpeed * Time.deltaTime;
    }
}
