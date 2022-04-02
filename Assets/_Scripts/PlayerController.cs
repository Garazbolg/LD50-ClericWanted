using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : AgentController
{
    protected override void Update()
    {
        var vertical = Input.GetAxisRaw("Vertical");
        var horizontal = Input.GetAxisRaw("Horizontal");

        input.horizontal = horizontal;
        input.vertical = vertical;

        base.Update();
    }
}
