using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLBrain
{
    public MLLayer[] layers;

    [System.Serializable]
    public struct LayerDefinition
    {
        public int LayerSize;
    }

    MLBrain(int inputSize, LayerDefinition[] layerdefs)
    {
        layers = new MLLayer[layerdefs.Length];
        var lastLayerSize = inputSize;
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i] = new MLLayer(layerdefs[i].LayerSize, lastLayerSize);
        }
    }

    MLBrain(MLBrain template)
    {
        layers = new MLLayer[template.layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i] = new MLLayer(template.layers[i]);
        }
    }

    public float[] Compute(float[] inputs)
    {
        float[] state = inputs;
        foreach (var layer in layers)
        {
            state = layer.Compute(state);
        }
        return state;
    }
}

public static class AF_Sigmoid
{
    public static float Compute(float value)
    {
        return 1.0f / (1f + Mathf.Exp(-value));
    }
}

public class Node
{
    public float[] Weights;
    public float Bias;

    public Node(int size)
    {
        Weights = new float[size];
        Bias = 0.2f;
    }

    public Node(Node template)
    {
        Weights = template.Weights.Clone() as float[];
        Bias = template.Bias;
    }

    public float Compute(float[] inputs)
    {
        if (inputs.Length != Weights.Length) throw new System.Exception("Invalide parameters : input size != weights size");
        float res = Bias;
        for (int i = 0; i < inputs.Length; i++)
        {
            res += inputs[i] * Weights[i];
        }
        return AF_Sigmoid.Compute(res);
    }
}

public class MLLayer
{
    public Node[] nodes;

    public MLLayer(int layerSize, int previousLayerSize)
    {
        nodes = new Node[layerSize];
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = new Node(previousLayerSize);
        }
    }

    public MLLayer(MLLayer template)
    {
        nodes = new Node[template.nodes.Length];
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = new Node(template.nodes[i]);
        }
    }

    public float[] Compute(float[] inputs)
    {
        float[] values = new float[nodes.Length];
        for (int i = 0; i < nodes.Length; i++)
        {
            values[i] = nodes[i].Compute(inputs);
        }
        return values;
    }
}