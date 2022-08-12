using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionSwitch : MonoBehaviour
{
    private enum QuestionSetId
    {
        Practice = 0,
        Experience = 1,
        VEQ = 2
    }
    [SerializeField] QuestionSetId questionSetId;
    private int questionId = 0;
    private TextMeshProUGUI questionTextMesh;
    private string[] questions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        questions = QuestionSet.sets[(int)questionSetId];
        questionTextMesh = gameObject.transform.Find("Panel").gameObject.transform.Find("Question").GetComponent<TextMeshProUGUI>();
        questionTextMesh.text = questions[questionId];
        AnswerButton.OnAnswered += HandleOnAnswered;
    }

    private void OnDisable()
    {
        AnswerButton.OnAnswered -= HandleOnAnswered;
    }

    private void HandleOnAnswered()
    {
        StartCoroutine(SwitchQuestion());
    }

    IEnumerator SwitchQuestion()
    {
        yield return new WaitForSeconds(1);
        if (++questionId < questions.Length)
        {
            questionTextMesh.text = questions[questionId];
        }
        else
        {
            string fileName = "practice";
            switch (questionSetId)
            {
                case QuestionSetId.Experience:
                    fileName = "experience";
                    break;
                case QuestionSetId.VEQ:
                    fileName = "VEQ";
                    break;
                default:
                    break;
            }
            QuestionnaireResultRecord.WriteRecordToFile(fileName);
            gameObject.SetActive(false);
        }
    }
}
