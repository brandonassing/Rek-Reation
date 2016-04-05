using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour {

    /// <summary>
    /// Controls scene changes
    /// </summary>
    /// 
    void Update()
    {
        UserValidation.timeElapsed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuMG");
        }
    }

    public void LoadPlay()
    {
        SceneManager.LoadScene("_Scene_0MG");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuMG");
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over MG");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Main Player Menu");
    }
}
