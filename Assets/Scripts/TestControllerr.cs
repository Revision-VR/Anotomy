using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Collections;

public class TestController : MonoBehaviour
{
    public Text questionText;
    public Button choiceA;
    public Button choiceB;
    public Button choiceS;

    public Button choiceD;
    public Button choiceF;
    public Button choiceG;


    public Button choiceH;
    public Button choiceI;
    public Button choiceJ;

    public Button Restart;

    public GameObject TurnOnAnim;
    public Animator CanvasAnim;


    public Text questionCounterText;
    public Text feedbackText;
    public Text correctAnswersText;
    public Text incorrectAnswersText;

    private List<Question> questions = new List<Question>();
    private int currentQuestionIndex = 0;
    private int totalQuestionsPerTest = 5;
    private int correctAnswers = 0;
    private int incorrectAnswers = 0;

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
        StartCoroutine(AnimationController1());
    }

    void InitializeQuestions()
    {
        questions.Add(new Question(" Qon aylanish sistemasidagi markaziy a'zo qaysi?", "A"));
        questions.Add(new Question(" Qonning qon tomirlar bo'ylab uzluksiz harakatini taminlaydigan a'zo...", "A"));
        questions.Add(new Question(" Nafas olish a'zosi qaysi?", "A"));
        questions.Add(new Question(" Ko'krak qafasining ikkala tomonini to'ldirib turadigan odam a'zosini toping.", "A"));
        //questions.Add(new Question(" Bu qaysi a'zo?", "A"));
        //questions.Add(new Question(" Bu qaysi a'zo?", "B"));
        //questions.Add(new Question(" Bu qaysi a'zo?", "S"));
        //questions.Add(new Question(" Buyrak qanday a'zo?", "A"));
        questions.Add(new Question(" Ovqatni saqlaydigan va uni maydalaydigan a'zo qaysi?", "S"));
        questions.Add(new Question(" Me'dadan kegin keladigan odam a'zosini toping.", "S"));
        questions.Add(new Question(" Nok shaklidagi kichik organ qaysi?", "B"));
        questions.Add(new Question(" Safroni to'plash va qayta ishlash a'zosi .....", "B"));
        questions.Add(new Question(" Odam skeletining  asosiy qismi nima?", "S"));

        questions.Add(new Question(" Ba'zi manbalarda me'da nomi bilan yuritiladigan odam a'zosi qaysi?", "A"));
        questions.Add(new Question(" Loviyasimon shaklga ega odam a'zosi ....", "S"));
        questions.Add(new Question(" Zararli moddalardan filtirlovchi organ qaysi?", "S"));

        //questions.Add(new Question(" Bu qaysi a'zo?", "A"));
        //questions.Add(new Question(" Bu qaysi a'zo?", "B"));
        //questions.Add(new Question(" Bu qaysi a'zo?", "S"));

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
            questionText.text = /*(currentQuestionIndex + 1) + ") " */currentQuestion.question;
            currentQuestionIndex++;
            questionCounterText.text = currentQuestionIndex + "/" + totalQuestionsPerTest;
            feedbackText.text = ""; // Clear previous feedback

            if (currentQuestion.question == " Odam skeletining  asosiy qismi nima?"
                || currentQuestion.question == " Safroni to'plash va qayta ishlash a'zosi ....."
                || currentQuestion.question == " Ko'krak qafasining ikkala tomonini to'ldirib turadigan odam a'zosini toping."
                || currentQuestion.question == " Nok shaklidagi kichik organ qaysi?"
                || currentQuestion.question == " Nafas olish a'zosi qaysi?")
            {
                choiceA.gameObject.SetActive(false);
                choiceB.gameObject.SetActive(false);
                choiceS.gameObject.SetActive(false);

                choiceH.gameObject.SetActive(false);
                choiceI.gameObject.SetActive(false);
                choiceJ.gameObject.SetActive(false);

                choiceD.gameObject.SetActive(true);
                choiceF.gameObject.SetActive(true);
                choiceG.gameObject.SetActive(true);
            }

            else if (currentQuestion.question == " Ba'zi manbalarda me'da nomi bilan yuritiladigan odam a'zosi qaysi?"
                     || currentQuestion.question == " Loviyasimon shaklga ega odam a'zosi ...."
                     || currentQuestion.question == " Zararli moddalardan filtirlovchi organ qaysi?")
            {
                choiceA.gameObject.SetActive(false);
                choiceB.gameObject.SetActive(false);
                choiceS.gameObject.SetActive(false);

                choiceD.gameObject.SetActive(false);
                choiceF.gameObject.SetActive(false);
                choiceG.gameObject.SetActive(false);

                choiceH.gameObject.SetActive(true);
                choiceI.gameObject.SetActive(true);
                choiceJ.gameObject.SetActive(true);

            }

            else
            {
                choiceA.gameObject.SetActive(true);
                choiceB.gameObject.SetActive(true);
                choiceS.gameObject.SetActive(true);

                choiceD.gameObject.SetActive(false);
                choiceF.gameObject.SetActive(false);
                choiceG.gameObject.SetActive(false);

                choiceH.gameObject.SetActive(false);
                choiceI.gameObject.SetActive(false);
                choiceJ.gameObject.SetActive(false);
            }
        }
        else
        {
            feedbackText.text = ""; // Clear previous feedback
            correctAnswersText.text = "To'g'ri javoblar: " + correctAnswers + "/5";
            //  incorrectAnswersText.text = "Incorrect Answers: " + incorrectAnswers + "/5";

            // Disable all UI elements related to the test
            Restart.gameObject.SetActive(true);
            correctAnswersText.gameObject.SetActive(true);
            //       incorrectAnswersText.gameObject.SetActive(true);
            questionText.gameObject.SetActive(false);
            choiceA.gameObject.SetActive(false);
            choiceB.gameObject.SetActive(false);
            choiceS.gameObject.SetActive(false);

            choiceD.gameObject.SetActive(false);
            choiceF.gameObject.SetActive(false);
            choiceG.gameObject.SetActive(false);

            choiceH.gameObject.SetActive(false);
            choiceI.gameObject.SetActive(false);
            choiceJ.gameObject.SetActive(false);

            questionCounterText.gameObject.SetActive(false);
            feedbackText.gameObject.SetActive(false);

            Debug.Log("Test completed!"); // Or any other action you want to take when the test is finished
        }
    }


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
            feedbackText.text = "To'g'ri!";
            feedbackText.color = new Color(0.0f, 0.5f, 0.0f);// Change text color to green for correct answer
            correctAnswers++;
        }
        else
        {
            feedbackText.text = "Noto'g'ri!";
            feedbackText.color = Color.red; // Change text color to red for incorrect answer
            incorrectAnswers++;
        }

        // Display feedback for a short duration, then show the next question
        Invoke("ShowNextQuestion", 1f); // Adjust the duration as needed
    }

    public IEnumerator AnimationController1()
    {
        TurnOnAnim.SetActive(true);
        CanvasAnim.Play("TurnOnAnim");
        yield return new WaitForSeconds(1f);
    }

    public void RestartTest()
    {
        // Reset variables
        currentQuestionIndex = 0;
        correctAnswers = 0;
        incorrectAnswers = 0;

        // Reset UI elements
        Restart.gameObject.SetActive(false);
        correctAnswersText.gameObject.SetActive(false);
        incorrectAnswersText.gameObject.SetActive(false);
        questionText.gameObject.SetActive(true);
        choiceA.gameObject.SetActive(true);
        choiceB.gameObject.SetActive(true);
        choiceS.gameObject.SetActive(true);
        choiceD.gameObject.SetActive(false);
        choiceF.gameObject.SetActive(false);
        choiceG.gameObject.SetActive(false);
        questionCounterText.gameObject.SetActive(true);
        feedbackText.gameObject.SetActive(true);

        ShuffleQuestions();
        // Restart the test
        StartNewTest();
    }

}
