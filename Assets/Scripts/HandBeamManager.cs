using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBeamManager : MonoBehaviour
{
    public delegate void PointingAction(int answerNum);
    public static event PointingAction OnPointing;
    
    private int currentPointingAnswerNum = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Answer"))
        {
            int answerNum = other.gameObject.GetComponent<AnswerButton>().Num;
            if (answerNum != currentPointingAnswerNum)
            {
                OnPointing?.Invoke(answerNum);
                currentPointingAnswerNum = answerNum;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Answer"))
        {
            OnPointing?.Invoke(0);
            currentPointingAnswerNum = 0;
        }
    }
}
