using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    /// <summary>
    /// Used for scene changes
    /// </summary>

    ///Start memory game
    public void MemoryStart()
    {
        GameObject.Find("music1(Clone)").GetComponent<AudioSource>().Stop();
        GameObject.Find("music2(Clone)").GetComponent<AudioSource>().Stop();

        SceneManager.LoadScene("MenuMG");
    }
    //Start rock paper scissors
    public void RPSStart()
    {
        GameObject.Find("music1(Clone)").GetComponent<AudioSource>().Stop();
        GameObject.Find("music2(Clone)").GetComponent<AudioSource>().Stop();

        SceneManager.LoadScene("MenuRPS");
    }
    //Start apple picker
    public void AppleStart()
    {
        GameObject.Find("music1(Clone)").GetComponent<AudioSource>().Stop();
        GameObject.Find("music2(Clone)").GetComponent<AudioSource>().Stop();

        SceneManager.LoadScene("Start ScreenAP");
    }
    //Start space shooter
    public void ShootStart()
    {
        GameObject.Find("music1(Clone)").GetComponent<AudioSource>().Stop();
        GameObject.Find("music2(Clone)").GetComponent<AudioSource>().Stop();

        SceneManager.LoadScene("Start Screen");
    }
    public void OpenGameLevel()
    {
        SceneManager.LoadScene("Game Levels");

    }
    public void OpenShootConfig()
    {
        SceneManager.LoadScene("Configurations");
    }

    //Log out user
    public void LogOut()
    {
        Destroy(GameObject.Find("music1(Clone)"));
        Destroy(GameObject.Find("music2(Clone)"));

        UserValidation.userList[UserValidation.activeUserIndex].AddActivity(UserValidation.dateTime, UserValidation.timeElapsed);
        UserValidation.Save();
        SceneManager.LoadScene("Main Login");
    }
    //Shut down
    public void QuitFromMain()
    {
        UserValidation.userList[UserValidation.activeUserIndex].AddActivity(UserValidation.dateTime, UserValidation.timeElapsed);
        UserValidation.Save();
        Quit();
    }
    //close package
    public void Quit()
    {
        Application.Quit();
    }
    //open main menu
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main Player Menu");
    }
    //open login history
    public void OpenHistoryMain()
    {
        UserValidation.Save();
        SceneManager.LoadScene("History Main");
    }

    //Used to change game history scene
    public static string gameHistoryType;
    //Open game history
    public void OpenHistoryGame(string type)
    {
        UserValidation.Save();
        gameHistoryType = type;
        SceneManager.LoadScene("History Game");
    }

    //Play sound used for button press
    public void PlaySound()
    {
        UserValidation.clickSound.GetComponent<AudioSource>().Play();
    }
}
