using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : AgentController
{
    protected override void Update()
    {
        var vertical = Input.GetAxisRaw("Vertical");
        var horizontal = Input.GetAxisRaw("Horizontal");

        input.down = vertical == -1;
        input.up = vertical == 1;
        input.left = horizontal == -1;
        input.right = horizontal == 1;

        base.Update();
    }
}
