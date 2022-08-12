using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCalibration : MonoBehaviour
{
    [SerializeField] private GameObject avatar;
    [SerializeField] private Transform head;
    [SerializeField] private Transform waist;
    [SerializeField] [Range(-1f, 1f)] private float headWaistLocalPosY;
    [SerializeField] [Range(-1f, 1f)] private float headLocalPosZ = -0.2f;
    [SerializeField] [Range(-1f, 1f)] private float waistLocalPosZ;

    private bool isStarted = false;

    private void Start()
    {
        isStarted = true;
        Calibration();
    }

    private void OnValidate()
    {
        if (isStarted) Calibration();
    }

    private void Calibration()
    {
        head.localPosition = new Vector3(head.localPosition.x, headWaistLocalPosY, headLocalPosZ);
        waist.localPosition = new Vector3(waist.localPosition.x, headWaistLocalPosY, waistLocalPosZ);
    }
}
