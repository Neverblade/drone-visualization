using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private Rigidbody rigidBody;

    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {

        // Translational movement
        float leftRight = Input.GetAxis("Horizontal");
        float forwardBack = Input.GetAxis("Vertical");
        float upDown = 0;
        if (Input.GetKey(KeyCode.E)) {
            upDown = 1;
        } else if (Input.GetKey(KeyCode.Q)) {
            upDown = -1;
        }
        Vector3 movement = new Vector3(leftRight, upDown, forwardBack).normalized;
        transform.Translate(movement * speed * Time.deltaTime, Space.Self);

        // Rotational movement
        float rotDir = 0;
        if (Input.GetKey(KeyCode.J)) {
            rotDir = -1;
        } else if (Input.GetKey(KeyCode.K)) {
            rotDir = 1;
        }
        transform.Rotate(new Vector3(0, rotDir * turnSpeed * Time.deltaTime, 0));
    }
}
