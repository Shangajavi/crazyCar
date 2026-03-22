using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private GameObject Orientation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float driveSpeed, steerSpeed;
    [SerializeField] private WheelCollider wheel1, wheel2, wheel3, wheel4;
    [SerializeField] private float forceImpulse;
    [SerializeField] private bool HasitPassed1 = false, HasitPassed2 = false;
    [SerializeField] private TextMeshProUGUI countCoin;
    [SerializeField] private TextMeshProUGUI countTimer;
    [SerializeField] private TextMeshProUGUI TotalPoints;
    public int coin;
    private AudioSource audioCoin;
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private GameObject Win;
    [SerializeField] private AudioClip audioCoinT;
    [SerializeField] private AudioClip AudioCar;
    [SerializeField] private bool isPlaying = true;
    private float time;
    private float TotaltimePointss;
    [SerializeField] private float timer = 500f;
    public float timePoints;

    float hInput,vInput;

    void Awake()
    {
        audioCoin = GetComponent<AudioSource>();
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
       if (isPlaying == true)
       {
           timePoints = timer - time;
       }
       else
       {
            TotaltimePointss = timePoints;
       }
       Coins();
       Timer();
       Points();

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
            audioCoin.PlayOneShot(audioCoinT);
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
        if (other.gameObject.CompareTag("Destination3"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
        }
        if (other.gameObject.CompareTag("End"))
        {
            isPlaying = false;
            StartCoroutine(WinDelay());
        }
        
    }

    private void Coins()
    {
        countCoin.text = "Coins: " + coin;
        
    }

    private void Points()
    {
        TotalPoints.text = "Total Points: " + coin + TotaltimePointss/2;
    }

    private void Timer()
    {
        countTimer.text = "Time: " + timePoints;
        if (timePoints >= 0)
        {
            countTimer.color = Color.cornflowerBlue;
        }
        if (timePoints <= 0)
        {
            countTimer.color = Color.red;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        audioCoin.PlayOneShot(AudioCar);
        if (other.gameObject.CompareTag("kill"))
        {
            StartCoroutine(RespawnDelay());
        }
    }
    private IEnumerator RespawnDelay()
    {
        DeathScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator WinDelay()
    {
        Win.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
    }

}
