using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject Destination;
    private Vector3 DestinationPos;

    // Update is called once per frame
    void Update()
    {
        DestinationPos = Destination.transform.position;
        transform.LookAt(DestinationPos);
    }
}
