using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateMeterPlatform : MonoBehaviour
{
    [SerializeField] Transform MeterStickAnchor;

    private void OnEnable()
    {
        gameObject.transform.position = new Vector3(MeterStickAnchor.position.x, MeterStickAnchor.position.y, MeterStickAnchor.position.z - gameObject.transform.localScale.z / 2);
    }
}
