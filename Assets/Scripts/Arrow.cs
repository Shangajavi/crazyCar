using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject Destination1;
    [SerializeField] private GameObject Destination2;
    [SerializeField] private GameObject Destination3;
     public bool HasitPassed1 = false;
    public bool HasitPassed2 = false;
    private Vector3 DestinationPos;

    // Update is called once per frame
    void Update()
    {
        if (HasitPassed1 == false && HasitPassed2 == false)
        {
            DestinationPos = Destination1.transform.position;
        }

        if (HasitPassed1 == true && HasitPassed2 == false)
        {
            DestinationPos = Destination2.transform.position;
        }

        if (HasitPassed1 == true && HasitPassed2 == true)
        {
            DestinationPos = Destination3.transform.position;
        }
        
        transform.LookAt(DestinationPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destination1"))
        {
            HasitPassed1 = true;
        }

        if (other.gameObject.CompareTag("Destination2"))
        {
            HasitPassed2 = true;
        }
    }
}
