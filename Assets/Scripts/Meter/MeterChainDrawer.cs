using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterChainDrawer : MonoBehaviour
{
    [SerializeField] Transform meterStickAnchor;
    [SerializeField] Transform meterPlatform;

    private LineRenderer chain;

    // Start is called before the first frame update
    void Start()
    {
        chain = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        chain.SetPosition(0, meterStickAnchor.position);
        chain.SetPosition(1, new Vector3(meterPlatform.position.x, meterPlatform.position.y, meterPlatform.position.z + meterPlatform.localScale.z / 2));
    }
}
