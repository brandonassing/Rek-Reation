using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

    /// <summary>
    /// Used to store and alter high score
    /// </summary>
    /// 
    public static int score = 0;
	
	void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }
	void Update () {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
	}
}
