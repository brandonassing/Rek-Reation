using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameLevelSettings : MonoBehaviour
{
    /// <summary>
    /// Used to control/save game level settings
    /// </summary>

    static public int[] maxEnemies = new int[3];
    static public int[] highestScore = new int[3];

    public static GameLevelSettings instanceRef;

    static public int[,] inactiveEnemies = new int[3, 5];

    public GameObject invalidGO;
    float displayTime;
    bool invalid = false;
    static public bool wasActivated = false;

    GameObject numEnemiesIN, scoreIN;
    GameObject[] activeToggle = new GameObject[5];

    void Awake()
    {
        if (!wasActivated)
        {
            InitialSetValues();
        }
        wasActivated = true;

    }

    void Start()
    {
        invalidGO = GameObject.Find("Invalid");
        invalidGO.SetActive(false);

        scoreIN = GameObject.Find("HighestScore");
        numEnemiesIN = GameObject.Find("NumEnemies");

        activeToggle[0] = GameObject.Find("Enemy1");
        activeToggle[1] = GameObject.Find("Enemy2");
        activeToggle[2] = GameObject.Find("Enemy3");
        activeToggle[3] = GameObject.Find("Enemy4");
        activeToggle[4] = GameObject.Find("Enemy5");

        WriteValues();
    }

    void WriteValues()
    {
        if (SceneManager.GetActiveScene().name == "Game Levels Bronze")
        {
            scoreIN.GetComponent<InputField>().text = highestScore[0].ToString();
            numEnemiesIN.GetComponent<InputField>().text = maxEnemies[0].ToString();

            for (int i = 0; i < activeToggle.Length; i++)
            {
                if (inactiveEnemies[0, i] == -1)
                {
                    activeToggle[i].GetComponent<Toggle>().isOn = true;
                }
                else
                {
                    activeToggle[i].GetComponent<Toggle>().isOn = false;
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Game Levels Silver")
        {
            scoreIN.GetComponent<InputField>().text = highestScore[1].ToString();
            numEnemiesIN.GetComponent<InputField>().text = maxEnemies[1].ToString();

            for (int i = 0; i < activeToggle.Length; i++)
            {
                if (inactiveEnemies[1, i] == -1)
                {
                    activeToggle[i].GetComponent<Toggle>().isOn = true;
                }
                else
                {
                    activeToggle[i].GetComponent<Toggle>().isOn = false;
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Game Levels Gold")
        {
            scoreIN.GetComponent<InputField>().text = highestScore[2].ToString();
            numEnemiesIN.GetComponent<InputField>().text = maxEnemies[2].ToString();

            for (int i = 0; i < activeToggle.Length; i++)
            {
                if (inactiveEnemies[2, i] == -1)
                {
                    activeToggle[i].GetComponent<Toggle>().isOn = true;
                }
                else
                {
                    activeToggle[i].GetComponent<Toggle>().isOn = false;
                }
            }
        }
    }

    //Assigns preset values to max enemies and highest score for each game level
    public static void InitialSetValues()
    {
        for (int i = 0; i < maxEnemies.Length; i++)
        {
            maxEnemies[i] = 5 + i * 2;
            highestScore[i] = 1000 + i * 500;
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                inactiveEnemies[i, j] = -1;
            }
        }

    }

    //*******************************************USED FOR ENEMY TOGGLE BRONZE*******************************************************************
    public void ToggleEnemy0_0(bool value)
    {
        if (value)
        {
            inactiveEnemies[0, 0] = -1;
        }
        else
            inactiveEnemies[0, 0] = 0;
    }
    public void ToggleEnemy0_1(bool value)
    {
        if (value)
        {
            inactiveEnemies[0, 1] = -1;
        }
        else
            inactiveEnemies[0, 1] = 1;
    }
    public void ToggleEnemy0_2(bool value)
    {
        if (value)
        {
            inactiveEnemies[0, 2] = -1;
        }
        else
            inactiveEnemies[0, 2] = 2;
    }
    public void ToggleEnemy0_3(bool value)
    {
        if (value)
        {
            inactiveEnemies[0, 3] = -1;
        }
        else
            inactiveEnemies[0, 3] = 3;
    }
    public void ToggleEnemy0_4(bool value)
    {
        if (value)
        {
            inactiveEnemies[0, 4] = -1;
        }
        else
            inactiveEnemies[0, 4] = 4;
    }
    //*******************************************USED FOR ENEMY TOGGLE SILVER*******************************************************************
    public void ToggleEnemy1_0(bool value)
    {
        if (value)
        {
            inactiveEnemies[1, 0] = -1;
        }
        else
            inactiveEnemies[1, 0] = 0;
    }
    public void ToggleEnemy1_1(bool value)
    {
        if (value)
        {
            inactiveEnemies[1, 1] = -1;
        }
        else
            inactiveEnemies[1, 1] = 1;
    }
    public void ToggleEnemy1_2(bool value)
    {
        if (value)
        {
            inactiveEnemies[1, 2] = -1;
        }
        else
            inactiveEnemies[1, 2] = 2;
    }
    public void ToggleEnemy1_3(bool value)
    {
        if (value)
        {
            inactiveEnemies[1, 3] = -1;
        }
        else
            inactiveEnemies[1, 3] = 3;
    }
    public void ToggleEnemy1_4(bool value)
    {
        if (value)
        {
            inactiveEnemies[1, 4] = -1;
        }
        else
            inactiveEnemies[1, 4] = 4;
    }
    //*******************************************USED FOR ENEMY TOGGLE GOLD*******************************************************************
    public void ToggleEnemy2_0(bool value)
    {
        if (value)
        {
            inactiveEnemies[2, 0] = -1;
        }
        else
            inactiveEnemies[2, 0] = 0;
    }
    public void ToggleEnemy2_1(bool value)
    {
        if (value)
        {
            inactiveEnemies[2, 1] = -1;
        }
        else
            inactiveEnemies[2, 1] = 1;
    }
    public void ToggleEnemy2_2(bool value)
    {
        if (value)
        {
            inactiveEnemies[2, 2] = -1;
        }
        else
            inactiveEnemies[2, 2] = 2;
    }
    public void ToggleEnemy2_3(bool value)
    {
        if (value)
        {
            inactiveEnemies[2, 3] = -1;
        }
        else
            inactiveEnemies[2, 3] = 3;
    }
    public void ToggleEnemy2_4(bool value)
    {
        if (value)
        {
            inactiveEnemies[2, 4] = -1;
        }
        else
            inactiveEnemies[2, 4] = 4;
    }
    //***********************************************USED FOR SCORE INPUT***************************************************************

    public void SetBronzeScore(string value)
    {
        try
        {
            int temp = int.Parse(value);
            if (temp >= highestScore[1])
            {
                invalid = true;
            }
            else
            {
                highestScore[0] = int.Parse(value);
                invalid = false;
            }
        }
        catch (FormatException e)
        {

        }
    }

    public void SetSilverScore(string value)
    {
        try
        {
            int temp = int.Parse(value);
            if (temp <= highestScore[0] || temp >= highestScore[2])
            {
                invalid = true;
            }
            else
            {
                highestScore[1] = int.Parse(value);
                invalid = false;
            }
        }
        catch (FormatException e)
        {

        }
    }
    public void SetGoldScore(string value)
    {
        try
        {
            int temp = int.Parse(value);
            if (temp <= highestScore[1])
            {
                invalid = true;
            }
            else
            {
                highestScore[2] = int.Parse(value);
                invalid = false;
            }
        }
        catch (FormatException e)
        {

        }
    }
    //==============================================USED FOR ENEMY COUNT INPUT=========================================================

    public void SetBronzeEnemies(string value)
    {
        try
        {
            int temp = int.Parse(value);
            if (temp >= maxEnemies[1])
            {
                invalid = true;
            }
            else
            {
                maxEnemies[0] = int.Parse(value);
                invalid = false;
            }
        }
        catch (FormatException e)
        {

        }
    }
    public void SetSilverEnemies(string value)
    {
        try
        {
            int temp = int.Parse(value);
            if (temp <= maxEnemies[0] || temp >= maxEnemies[2])
            {
                invalid = true;
            }
            else
            {
                maxEnemies[1] = int.Parse(value);
                invalid = false;
            }
        }
        catch (FormatException e)
        {

        }
    }
    public void SetGoldEnemies(string value)
    {
        try
        {
            int temp = int.Parse(value);
            if (temp <= maxEnemies[1])
            {
                invalid = true;
            }
            else
            {
                maxEnemies[2] = int.Parse(value);
                invalid = false;
            }
        }
        catch (FormatException e)
        {

        }
    }

    void Update()
    {
        if (invalid)
        {
            invalidGO.SetActive(true);
        }
        else
        {
            invalidGO.SetActive(false);
        }
    }
}
