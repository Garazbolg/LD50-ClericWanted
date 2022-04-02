using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Locomotion))]
public class AgentController : MonoBehaviour
{
    protected Locomotion.LocomotionInput input;

    private Locomotion loc;
    protected virtual void Awake()
    {
        loc = GetComponent<Locomotion>();
    }

    protected virtual void Update()
    {
        loc.Input = input;
    }
}
