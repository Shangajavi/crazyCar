using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private GameObject Orientation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float driveSpeed, steerSpeed;
    [SerializeField] private WheelCollider wheel1, wheel2, wheel3, wheel4;
    [SerializeField] private float forceImpulse;
    [SerializeField] private bool HasitPassed1 = false, HasitPassed2 = false;
    public bool isPlaying;
    public int coin;
    private float time;
    [SerializeField] private float timer = 500f;
    public float timePoints;

    float hInput,vInput;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       hInput = Input.GetAxis("Horizontal");
       vInput = Input.GetAxis("Vertical");
       Impulsos();
       time += Time.deltaTime;
       timePoints = timer - time;
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
            coin++;
        }
        if (other.gameObject.CompareTag("Destination1"))
        {
            Arrow.Hasitpassed(true,false);
        }

        if (other.gameObject.CompareTag("Destination2"))
        {
            Arrow.Hasitpassed(true,true);
        }
    }

}
