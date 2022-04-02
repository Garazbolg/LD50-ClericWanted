using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSensor : MonoBehaviour
{
    [SerializeField] private int rayCount = 5;
    [SerializeField] private float rayRadius = .4f;
    [SerializeField] private float maxDistance = 20;
    [SerializeField] private float fov = 90f;

    [System.Serializable]
    public struct SensorState
    {
        public float[] raysDistance;
    }

    public SensorState GetState()
    {
        SensorState state;
        state.raysDistance = new float[rayCount];
        RaycastHit hit;
        for (int i = 0; i < rayCount; i++)
        {
            float distance = maxDistance;
            float angle = ((fov / rayCount) * i - fov/2) * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
            direction = transform.TransformDirection(direction.normalized);
            if (Physics.SphereCast(transform.position,rayRadius,direction,out hit,maxDistance))
            {
                distance = hit.distance;
            }
            state.raysDistance[i] = 1/(distance*distance+0.1f);
        }

        return state;
    }

    private void OnDrawGizmosSelected()
    {
        RaycastHit hit;
        for (int i = 0; i < rayCount; i++)
        {
            float distance = 100;
            float angle = ((fov / rayCount) * i - fov / 2) * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            direction = transform.TransformDirection(direction.normalized);
            if (Physics.SphereCast(transform.position, rayRadius,direction, out hit, maxDistance))
            {
                distance = hit.distance;
            }
            Gizmos.DrawLine(transform.position, transform.position + direction * distance);
        }
    }
}
