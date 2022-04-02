using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MLManager : MonoBehaviour
{
    [SerializeField] private float computeFrequency = 4;
    [SerializeField] private int inputSize;
    [SerializeField] private int outputSize;
    [SerializeField] MLBrain.LayerDefinition[] layersDefinition;

    [SerializeField] protected float[] inputs;
    [SerializeField] protected float[] outputs;

    MLBrain brain;
    private float lastComputeTime = 0;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        inputs = new float[inputSize];
        outputs = new float[outputSize];
        brain = new MLBrain(inputSize, layersDefinition);
        brain.print();
    }

    public void Init(MLManager parent)
    {
        inputs = new float[parent.inputs.Length];
        outputs = new float[parent.outputs.Length];
        brain = new MLBrain(parent.brain);
    }

    private void Update()
    {
        if(brain != null)
        {
            if(Time.time - lastComputeTime > (1/computeFrequency))
            {
                lastComputeTime = Time.time;
                WriteInput();
                outputs =  brain.Compute(inputs);
                ReadOutput();
            }
        }
    }

    protected abstract void WriteInput();
    protected abstract void ReadOutput();
}
