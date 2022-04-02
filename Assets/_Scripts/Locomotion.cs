using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Locomotion : MonoBehaviour
{
    public struct LocomotionInput
    {
        public bool left;
        public bool right;
        public bool up;
        public bool down;
    }
    public LocomotionInput Input { get; set; }

    [SerializeField] private float speed = 5;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3((Input.left ? -1 : 0) + (Input.right ? 1 : 0), 0, (Input.down ? -1 : 0) + (Input.up ? 1 : 0));
        rb.velocity = direction.normalized * speed;
    }
}
