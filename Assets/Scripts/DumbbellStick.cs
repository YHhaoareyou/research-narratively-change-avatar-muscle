using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbbellStick : MonoBehaviour
{
    private float _maxDis = 0.5f;
    [SerializeField] private float _disWeightRatio = 0.5f;

    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = gameObject.transform.position;
        float dis = Vector3.Distance(lastPos, currentPos);
        if (dis < _maxDis)
        {
            BlendShapeController.GrowMuscle(dis * _disWeightRatio);
        }
        lastPos = currentPos;
    }
}
