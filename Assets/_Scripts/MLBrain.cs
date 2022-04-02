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
        public FloatArray[] weights;
        public float[] Biases;

        [System.Serializable]
        public struct FloatArray
        {
            public float[] value;
        }
    }

    public MLBrain(int inputSize, LayerDefinition[] layerdefs)
    {
        layers = new MLLayer[layerdefs.Length];
        var lastLayerSize = inputSize;
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i] = new MLLayer(layerdefs[i].LayerSize, lastLayerSize,layerdefs[i].weights,layerdefs[i].Biases);
            lastLayerSize = layers[i].nodes.Length;
        }
    }

    public MLBrain(MLBrain template)
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

    public void print()
    {
        string s = "";
        foreach (var layer in layers)
        {
            foreach(Node n in layer.nodes)
            {
                s += "(" + n.Bias + ";";
                foreach (var w in n.Weights)
                {
                    s += "," + w;
                }
                s += "),";
            }
            s += "\n";
        }
        Debug.Log(s);
    }
}

public static class AF_Sigmoid
{
    public static float Compute(float value)
    {
        return 1.0f / (1f + Mathf.Exp(-value));
    }
}

public static class AF_Linear
{
    public static float Compute(float value)
    {
        return value;
    }
}

public class Node
{
    public static float WeightVariance = 3f;
    public static float BiasVariance = 3f;
    public float[] Weights;
    public float Bias;

    public Node(int size)
    {
        Weights = new float[size];
        for (int i = 0; i < Weights.Length; i++)
        {
            Weights[i] = (Random.value * 2 - 1) * WeightVariance;
        }
        Bias = (Random.value * 2 - 1) * BiasVariance;
    }

    public Node(Node template)
    {
        Weights = template.Weights.Clone() as float[];
        for (int i = 0; i < Weights.Length; i++)
        {
            Weights[i] = Weights[i] + (Random.value * 2 - 1) * WeightVariance;
        }
        Bias = template.Bias + (Random.value * 2 - 1) * BiasVariance;
    }

    public float Compute(float[] inputs)
    {
        if (inputs.Length != Weights.Length) throw new System.Exception("Invalide parameters : input size != weights size. Input:" + inputs.Length + " weights:" + Weights.Length);
        float res = Bias;
        for (int i = 0; i < inputs.Length; i++)
        {
            res += inputs[i] * Weights[i];
        }
        return AF_Linear.Compute(res);
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

    public MLLayer(int layerSize, int previousLayerSize, MLBrain.LayerDefinition.FloatArray[] weights, float[] biases)
    {
        nodes = new Node[layerSize];
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = new Node(previousLayerSize);
            nodes[i].Weights = weights[i].value;
            nodes[i].Bias = biases[i];
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