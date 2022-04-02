using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Locomotion : MonoBehaviour
{
    [System.Serializable]
    public struct LocomotionInput
    {
        public float horizontal;
        public float vertical;
    }
    public LocomotionInput Input;

    [SerializeField] private float speed = 5;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.horizontal, 0, Input.vertical);
        rb.velocity = direction.normalized * speed;
    }
}
