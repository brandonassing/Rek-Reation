using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySettings : MonoBehaviour
{
    /// <summary>
    /// Used to control/save enemy settings
    /// </summary>

    static public int[] enemyColor = new int[5];
    public Dropdown[] d = new Dropdown[5];
    static public int[] index = new int[5];

    public InputField[] eIN = new InputField[5];
    static public int[] enemyScore = new int[5];

    static public bool wasActivated = false;

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
        for (int i = 0; i < index.Length; i++)
        {
            d[i].value = index[i];
            eIN[i].text = enemyScore[i].ToString();
        }
    }

    //Used to set enemy score to preset values
    public static void InitialSetValues()
    {
        for (int i = 0; i < index.Length; i++)
        {
            enemyScore[i] = 100 + i * 100;
        }
    }

    //============================USED TO SET/GET ENEMY SCORE=========================================================
    public void SetScore0(string value)
    {
        enemyScore[0] = int.Parse(value);
    }
    public void SetScore1(string value)
    {
        enemyScore[1] = int.Parse(value);
    }
    public void SetScore2(string value)
    {
        enemyScore[2] = int.Parse(value);
    }
    public void SetScore3(string value)
    {
        enemyScore[3] = int.Parse(value);
    }
    public void SetScore4(string value)
    {
        enemyScore[4] = int.Parse(value);
    }
    public static int getScore(int enemyType)
    {
        return enemyScore[enemyType];
    }

    //==============================USED TO SET/GET ENEMY COLOUR==========================================================
    public void SetColor()
    {
        for (int i = 0; i < enemyColor.Length; i++)
        {
            enemyColor[i] = d[i].value;
            index[i] = d[i].value;
        }
        ///option in dropdown changes back to white on scene load
    }
    public static Color getColor(int enemyType)
    {
        switch (enemyColor[enemyType])
        {
            case 0:
                return Color.white;
            case 1:
                return Color.red;
            case 2:
                return Color.blue;
            case 3:
                return Color.green;
            case 4:
                return Color.yellow;
            case 5:
                return Color.magenta;
            default:
                return Color.white;
        }

    }

}
