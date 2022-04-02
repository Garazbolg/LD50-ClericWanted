using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PreyMLManager))]
[RequireComponent(typeof(Locomotion))]
public class MLController : MonoBehaviour
{
    private Locomotion loc;
    private PreyMLManager agent;

    private void Awake()
    {
        loc = GetComponent<Locomotion>();
        agent = GetComponent<PreyMLManager>();
    }

    void Update()
    {
        loc.Input = agent.outputStruct.loc;
    }
}
