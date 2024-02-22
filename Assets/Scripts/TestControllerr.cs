using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestControllerr : MonoBehaviour
{
    public Text questionText;
    public Button choiceA;
    public Button choiceB;
    public Button choiceS;
    public Text questionCounterText;
    public Text feedbackText;

    private List<Question> questions = new List<Question>();
    private int currentQuestionIndex = 0;
    private int totalQuestionsPerTest = 5;

    private class Question
    {
        public string question;
        public string answer;

        public Question(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }
    }

    void Start()
    {
        InitializeQuestions();
        StartNewTest();
    }

    void InitializeQuestions()
    {
        questions.Add(new Question(" Qon aylanish sistemasidagi markaziy a'zo qaysi?", "A"));
        questions.Add(new Question(" Qonning qon tomirlar bo'ylab uzluksiz harakatini taminlaydigan a'zo...", "B"));
        questions.Add(new Question(" Nafas olish a'zosi qaysi?", "S"));
        questions.Add(new Question(" Bu qaysi a'zo?", "A"));
        questions.Add(new Question(" Bu qaysi a'zo?", "B"));
        questions.Add(new Question(" Bu qaysi a'zo?", "S"));
        questions.Add(new Question(" Buyrak qanday a'zo?", "A"));
        questions.Add(new Question(" Ovqatni saqlaydigan va uni maydalaydigan a'zo qaysi?", "B"));
        questions.Add(new Question(" Me'dadan kegin keladigan odam a'zosini toping.", "S"));
        questions.Add(new Question(" Nok shaklidagi kichik organ qaysi?", "A"));
        questions.Add(new Question(" Ot pufagning asosiy vazifasini toping.", "B"));
        questions.Add(new Question(" Skeletning asosiy qismi nima deb ataladi?", "S"));
        questions.Add(new Question(" Bu qaysi a'zo?", "A"));
        questions.Add(new Question(" Bu qaysi a'zo?", "B"));
        questions.Add(new Question(" Bu qaysi a'zo?", "S"));

        ShuffleQuestions();
    }

    void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            Question temp = questions[i];
            int randomIndex = Random.Range(i, questions.Count);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
    }

    void StartNewTest()
    {
        currentQuestionIndex = 0;
        ShowNextQuestion();
    }

    void ShowNextQuestion()
    {
        if (currentQuestionIndex < totalQuestionsPerTest)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            // Concatenate the question number with the question text
            questionText.text = (currentQuestionIndex + 1) + ") " + currentQuestion.question;
            currentQuestionIndex++;
            questionCounterText.text = "Question " + currentQuestionIndex + " of " + totalQuestionsPerTest;
            feedbackText.text = ""; // Clear previous feedback
        }
        else
        {
            Debug.Log("Test completed!"); // Or any other action you want to take when the test is finished
        }
    }


// These methods would be called by the respective buttons in Unity
public void ChooseA()
    {
        CheckAnswer("A");
    }

    public void ChooseB()
    {
        CheckAnswer("B");
    }

    public void ChooseS()
    {
        CheckAnswer("S");
    }

    void CheckAnswer(string chosenAnswer)
    {
        Question currentQuestion = questions[currentQuestionIndex - 1];
        if (chosenAnswer == currentQuestion.answer)
        {
            feedbackText.text = "Correct!";
        }
        else
        {
            feedbackText.text = "Incorrect!";
        }

        ShowNextQuestion();
    }
}
