using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public int Cost = 50;
    public Sprite sprite;
    public string component;

    public void Equip(GameObject go)
    {
        go.AddComponent(System.Type.GetType(component));
    }
}
