using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public delegate void AnsweredAction();
    public static event AnsweredAction OnAnswered;

    [SerializeField] private int num = 0;
    private bool isPointed = false;
    private float pointedSec = 0;

    public int Num
    {
        get { return num; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPointed)
        {
            pointedSec += Time.deltaTime;
        }
        if (pointedSec >= 2)
        {
            OnSelected();
        }
    }

    private void OnEnable()
    {
        ActivateListeners();
    }

    private void OnDisable()
    {
        DeactivateListeners();
    }

    private void HandlePointed(int pointedNum)
    {
        if (pointedNum == num)
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 0, 100);
            isPointed = true;
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            isPointed = false;
            pointedSec = 0;
        }
    }

    private void OnSelected()
    {
        QuestionnaireResultRecord.AddAnswer(num);
        gameObject.GetComponent<Image>().color = new Color32(0, 255, 0, 100);
        isPointed = false;
        pointedSec = 0;
        OnAnswered?.Invoke();
    }

    private void HandleAnswered()
    {
        StartCoroutine(Reset());
    }

    private void ActivateListeners()
    {
        HandBeamManager.OnPointing += HandlePointed;
        AnswerButton.OnAnswered += HandleAnswered;
    }

    private void DeactivateListeners()
    {
        HandBeamManager.OnPointing -= HandlePointed;
        AnswerButton.OnAnswered -= HandleAnswered;
    }

    IEnumerator Reset()
    {
        DeactivateListeners();
        yield return new WaitForSeconds(1);
        ActivateListeners();
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
    }
}
