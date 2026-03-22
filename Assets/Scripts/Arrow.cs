using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject Destination1;
    [SerializeField] private GameObject Destination2;
    [SerializeField] private GameObject Destination3;
     public static bool HasitPassed1 = false;
     public static bool HasitPassed2 = false;
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



    public static void Hasitpassed(bool point1,bool point2)
    {
        if (point1 == true)
        {
            HasitPassed1 = true;
        }
        if (point2 == true)
        {
            HasitPassed2 = true;
        }
    }
    
}
