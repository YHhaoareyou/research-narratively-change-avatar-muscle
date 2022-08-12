using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbbell : MonoBehaviour
{
    [SerializeField] Transform DumbbellAnchor;
    bool isOnHand = false;
    Transform hand;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = DumbbellAnchor.localRotation;
        gameObject.transform.position = isOnHand && hand != null ? hand.position : DumbbellAnchor.position;
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            hand = collision.gameObject.transform;
            isOnHand = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            hand = null;
            isOnHand = false;
        }
    }
    */
}
