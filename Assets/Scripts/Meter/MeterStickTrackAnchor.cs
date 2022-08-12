using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterStickTrackAnchor : MonoBehaviour
{
    [SerializeField] Transform anchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = anchor.position;
        gameObject.transform.rotation = anchor.rotation;
        gameObject.transform.localRotation = Quaternion.Euler(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y, gameObject.transform.localEulerAngles.z + 90);
    }
}
