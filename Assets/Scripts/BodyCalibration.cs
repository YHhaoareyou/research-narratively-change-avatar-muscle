using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCalibration : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform waist;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] [Range(-0.5f, 0.5f)] private float headLocalPos;
    [SerializeField] [Range(-0.5f, 0.5f)] private float waistLocalPos;
    [SerializeField] [Range(-0.5f, 0.5f)] private float leftHandLocalPos;
    [SerializeField] [Range(-0.5f, 0.5f)] private float rightHandLocalPos;
    [SerializeField] [Range(-0.5f, 0.5f)] private float leftFootLocalPos;
    [SerializeField] [Range(-0.5f, 0.5f)] private float rightFootLocalPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        head.localPosition = new Vector3(head.localPosition.x, headLocalPos, head.localPosition.z);
        waist.localPosition = new Vector3(waist.localPosition.x, waistLocalPos, waist.localPosition.z);
        leftHand.localPosition = new Vector3(leftHand.localPosition.x, leftHandLocalPos, leftHand.localPosition.z);
        rightHand.localPosition = new Vector3(rightHand.localPosition.x, rightHandLocalPos, rightHand.localPosition.z);
        leftFoot.localPosition = new Vector3(leftFoot.localPosition.x, leftFootLocalPos, leftFoot.localPosition.z);
        rightFoot.localPosition = new Vector3(rightFoot.localPosition.x, rightFootLocalPos, rightFoot.localPosition.z);
    }
}
