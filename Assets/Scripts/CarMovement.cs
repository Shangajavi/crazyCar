using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private GameObject Orientation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float driveSpeed, steerSpeed;
    [SerializeField] private WheelCollider wheel1, wheel2, wheel3, wheel4;
    [SerializeField] private float forceImpulse;
    float hInput,vInput;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       hInput = Input.GetAxis("Horizontal");
       vInput = Input.GetAxis("Vertical");
       Impulsos();
    }

    private void FixedUpdate()
    {
        float motor = vInput * driveSpeed;
        wheel1.motorTorque = motor;
        wheel2.motorTorque = motor;
        wheel3.motorTorque = motor;
        wheel4.motorTorque = motor;
        wheel1.steerAngle = hInput * steerSpeed;
        wheel2.steerAngle = hInput * steerSpeed;
    }

    private void Impulsos()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            rb.AddForce(-Orientation.transform.right * forceImpulse, ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            rb.AddForce(Orientation.transform.right * forceImpulse, ForceMode.Impulse);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
