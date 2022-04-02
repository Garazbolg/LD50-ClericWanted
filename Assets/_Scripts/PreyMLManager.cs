using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ViewSensor))]
public class PreyMLManager : MLManager
{
    #region Struct Definition
    public struct PreyInput
    {
        //public float stomachFillValue;
        //public float closestFoodDistance;
        public ViewSensor.SensorState sensorState;
    }

    public PreyInput inputStruct;

    public struct PreyOutput
    {
        public Locomotion.LocomotionInput loc;
    }
    public PreyOutput outputStruct;
    #endregion

    private ViewSensor sensor;

    private void Awake()
    {
        sensor = GetComponent<ViewSensor>();
    }

    protected override void ReadOutput()
    {
        outputStruct.loc.horizontal = Mathf.Clamp(outputs[0],-1,1);
        outputStruct.loc.vertical = Mathf.Clamp(outputs[1], -1, 1);
    }

    protected override void WriteInput()
    {
        List<float> inputFloats = new List<float>();
        inputStruct.sensorState = sensor.GetState();
        inputFloats.AddRange(inputStruct.sensorState.raysDistance);
        inputs = inputFloats.ToArray();
    }
}
