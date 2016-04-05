using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Controls scene changes 
public class Menu : MonoBehaviour {

    void Update()
    {
        UserValidation.timeElapsed += Time.deltaTime;
        //Used for android back button
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Main Player Menu");
    }

    //Loads game
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_0RPS");
    }

    //Loads menu
    public void OpenMenu()
    {
        SceneManager.LoadScene("MenuRPS");
    }

    //Closes application
    public void QuitGame()
    {
        SceneManager.LoadScene("Main Player Menu");
    }
}
