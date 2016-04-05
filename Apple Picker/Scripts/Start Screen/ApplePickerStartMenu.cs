using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ApplePickerStartMenu : MonoBehaviour
{
    public Button easyButton, medButton, hardButton, exitButton;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        easyButton.GetComponentInChildren<Text>().text = "Easy";
        medButton.GetComponentInChildren<Text>().text = "Medium";
        hardButton.GetComponentInChildren<Text>().text = "Hard";
        exitButton.GetComponentInChildren<Text>().text = "Exit Menu";
    }
    public void EasyStart()
    {
        SceneManager.LoadScene("_Scene_0AP");
    }
    public void MediumStart()
    {
        SceneManager.LoadScene("_Scene_1AP");
    }
    public void HardStart()
    {
        SceneManager.LoadScene("_Scene_2AP");
    }
    void Update()
    {
        UserValidation.timeElapsed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(); 
    }
    public void Exit()
    {
        SceneManager.LoadScene("Main Player Menu");
    }
}
