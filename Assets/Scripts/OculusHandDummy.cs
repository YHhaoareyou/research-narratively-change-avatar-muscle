using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusHandDummy : MonoBehaviour
{
    [SerializeField] Transform LeftHandAnchor;

    [SerializeField] Transform RightHandAnchor;

    [SerializeField] Transform LeftHandAnchorDummy;

    [SerializeField] Transform RightHandAnchorDummy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetLocalRotationDummy(LeftHandAnchor, LeftHandAnchorDummy);
        SetLocalRotationDummy(RightHandAnchor, RightHandAnchorDummy);
    }
    void SetLocalRotationDummy(Transform from , Transform to)
    {
        var fromRotation = from.localEulerAngles;
        var rotationX = fromRotation.x - 90;
        var rotationY = fromRotation.y;
        var rotationZ = fromRotation.z + 180;
        to.localRotation = Quaternion.Euler(new Vector3(rotationX, rotationY, rotationZ));

        to.position = from.position;
    }
}
