using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreAP : MonoBehaviour {

    public static int score = 1000;
	
	void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }
	void Update () {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        if (score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
	}
}
