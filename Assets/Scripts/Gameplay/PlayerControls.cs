using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public void Cast(int i)
    {
        PlayerController.Instance.Cast(i);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
            Cast(0);
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
            Cast(1);
        if (Input.GetKeyDown(KeyCode.E))
            Cast(2);
        if (Input.GetKeyDown(KeyCode.R))
            Cast(3);
    }
}
