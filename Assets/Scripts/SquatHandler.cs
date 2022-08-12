using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatHandler : MonoBehaviour
{
    [SerializeField] private bool isMuscleFixed = false;
    [SerializeField] private Transform WaistAnchor;
    [SerializeField] private AudioSource growMuscleSoundEffect;
    [SerializeField] private Transform avatar;
    
    private const float _squatSeconds = 1;
    private const float _squatPumpingSeconds = 0.5f;
    private const int _inflateScale = 100;
    private const int _deflateScale = -85;

    private Vector3 waistLastPos;
    private float waistDisplacement = 0;
    private float squatThreshold = 0.2f;
    private bool isSquatting = false;
    private bool isPumpingMuscle = false;

    // Start is called before the first frame update
    void Start()
    {
        waistLastPos = WaistAnchor.position;
        squatThreshold = avatar.localScale.y * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMuscleFixed) return;

        waistDisplacement += (WaistAnchor.position.y - waistLastPos.y);

        if (waistDisplacement <= -squatThreshold)
        {
            waistDisplacement = 0;
            growMuscleSoundEffect.Play();
            StartCoroutine(Squat());
        }

        if (waistDisplacement >= squatThreshold)
        {
            waistDisplacement = 0;
        }

        if (isSquatting)
        {
            BlendShapeController.GrowMuscle(Time.deltaTime * (isPumpingMuscle ? _inflateScale : _deflateScale));
        }

        waistLastPos = WaistAnchor.position;
    }

    IEnumerator Squat()
    {
        isPumpingMuscle = true;
        isSquatting = true;
        yield return new WaitForSeconds(_squatPumpingSeconds);
        isPumpingMuscle = false;
        yield return new WaitForSeconds(_squatSeconds - _squatPumpingSeconds);
        isSquatting = false;
    }
}
