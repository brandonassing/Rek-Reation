using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMG : MonoBehaviour
{

    /// <summary>
    /// Used for game control
    /// </summary>

    static public bool won;
    public ScreenManager SM;
    static public bool finished;

    static public int finalscore;
    static int score;
    public Text scoreGT;

    static public string finalMinutes, finalSeconds;
    public Text timerGT;
    static float timer;
    static bool timeStarted = false;
    string minutes, seconds;

    public AudioSource match, noMatch;

    public GameObject[] cards;

    GameObject card1, card2;

    Vector3[] positions;

    int cardsLeft = 18;

    string dateTime;


    void Awake()
    {
        cards = new GameObject[18];
        positions = new Vector3[cards.Length];
    }

    void Start()
    {
        dateTime = System.DateTime.Now.ToString();

        //Reset all values and text
        timer = 0;
        score = 1000;
        finished = true;
        finalscore = 0;
        won = false;
        minutes = "0";
        seconds = "0";

        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "SCORE: " + score;

        GameObject timerGO = GameObject.Find("Timer");
        timerGT = timerGO.GetComponent<Text>();
        timerGT.text = "TIMER: 00:00";
        timeStarted = true;

        //Reset cards
        AssignCards();
        ShuffleCards(cards);
        LayCards();

    }


    void Update()
    {
        //Update timer
        if (timeStarted == true)
        {
            timer += Time.deltaTime;
        }
        minutes = Mathf.Floor(timer / 60).ToString("00");
        seconds = Mathf.Floor(timer % 60).ToString("00");
        timerGT.text = "TIMER: " + minutes + ":" + seconds;

    }

    //Assigns cards an initial value in pairs
    void AssignCards()
    {
        cards[0] = GameObject.Find("Card (0)");
        cards[1] = GameObject.Find("Card (1)");
        cards[2] = GameObject.Find("Card (2)");
        cards[3] = GameObject.Find("Card (3)");
        cards[4] = GameObject.Find("Card (4)");
        cards[5] = GameObject.Find("Card (5)");
        cards[6] = GameObject.Find("Card (6)");
        cards[7] = GameObject.Find("Card (7)");
        cards[8] = GameObject.Find("Card (8)");
        cards[9] = GameObject.Find("Card (9)");
        cards[10] = GameObject.Find("Card (10)");
        cards[11] = GameObject.Find("Card (11)");
        cards[12] = GameObject.Find("Card (12)");
        cards[13] = GameObject.Find("Card (13)");
        cards[14] = GameObject.Find("Card (14)");
        cards[15] = GameObject.Find("Card (15)");
        cards[16] = GameObject.Find("Card (16)");
        cards[17] = GameObject.Find("Card (17)");

        for (int i = 0; i < cards.Length; i++)
        {
            positions[i] = cards[i].transform.position;
        }

        int count = 1;

        for (int i = 0; i < cards.Length; i += 2, count++)
        {
            cards[i].GetComponent<Card>().value = count;
            cards[i + 1].GetComponent<Card>().value = count;

        }
    }

    //Called when card is pressed. Called from Card.cs
    public void CardPressed(GameObject card)
    {
        //No cards flipped
        if (card1 == null)
        {
            card1 = card;
            card1.GetComponent<Card>().Rotate();
        }
        //Only one card flipped
        else
        {
            card2 = card;
            card2.GetComponent<Card>().Rotate();

            finished = false;
            Invoke("CheckCards", 1f);
        }

    }

    //Checks to see if cards match
    void CheckCards()
    {
        //Cards match
        if (card1.GetComponent<Card>().value == card2.GetComponent<Card>().value)
        {
            match.Play();
            Destroy(card1);
            Destroy(card2);
            cardsLeft -= 2;
            if (cardsLeft <= 0)
            {
                won = true;
                finalscore = score;
                finalMinutes = minutes;
                finalSeconds = seconds;

                UserValidation.userList[UserValidation.activeUserIndex].AddGame("Memory", finalscore, UserValidation.userList[UserValidation.activeUserIndex].username, dateTime);
                UserValidation.Save();
                SM.LoadGameOver();
            }
        }
        //Cards don't match
        else
        {
            noMatch.Play();
            score -= 40;

            scoreGT.text = "SCORE: " + score;

            card1.GetComponent<Card>().Rotate();
            card2.GetComponent<Card>().Rotate();

            if (score <= 0)
            {
                won = false;
                finalscore = 0;
                finalMinutes = minutes;
                finalSeconds = seconds;

                UserValidation.userList[UserValidation.activeUserIndex].AddGame("Memory", finalscore, UserValidation.userList[UserValidation.activeUserIndex].username, dateTime);
                UserValidation.Save();
                SM.LoadGameOver();
            }

        }
        card1 = null;
        card2 = null;
        finished = true;
    }

    //Shuffles cards position
    public static void ShuffleCards(GameObject[] cards)
    {
        System.Random rand = new System.Random();
        int i = 18;
        while (i > 1)
        {
            i--;
            int j = rand.Next(i);
            GameObject value = cards[j];
            cards[j] = cards[i];
            cards[i] = value;
        }
    }

    //Resets card positions
    void LayCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = positions[i];
        }
    }

}
