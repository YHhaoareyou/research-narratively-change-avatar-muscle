using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDummy : MonoBehaviour
{
    [SerializeField] Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = hand.position;
        gameObject.transform.rotation = hand.rotation;
        //gameObject.transform.eulerAngles = new Vector3(hand.eulerAngles.x, 90, 90);
        /*
        float angle = hand.eulerAngles.x;
        angle = (angle > 180) ? angle - 360 : angle;
        Debug.Log(angle);
        gameObject.transform.eulerAngles = new Vector3(angle, 90, 90);
        */
    }
}
