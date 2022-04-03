using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public ClassInspector playerInspector;

    public GameObject selectedUnit;

    private void Awake()
    {
        Instance = this;
    }
}
