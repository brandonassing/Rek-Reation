using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainStart : MonoBehaviour
{
    /// <summary>
    /// Used to control scene changes
    /// </summary>

    void Awake()
    {
        Utils.SetCameraBounds(this.GetComponent<Camera>());
        UnityEngine.Cursor.visible = true;

    }
    void Update()
    {
        UserValidation.timeElapsed += Time.deltaTime;
    }

    public void StartGame()
    {

        SceneManager.LoadScene("_Scene_0");
    }

    public void QuitGame()
    {
        //stops background music
        Destroy(GameObject.Find("background1(Clone)"));
        Destroy(GameObject.Find("background2(Clone)"));
        Destroy(GameObject.Find("background3(Clone)"));
        Destroy(GameObject.Find("ClickSound"));
        SceneManager.LoadScene("Main Player Menu");
    }

    public void LoadStart()
    {

        SceneManager.LoadScene("Start Screen");
    }

    public void LoadInstructions()
    {

        SceneManager.LoadScene("Help");
    }

    public void LoadGameMenu()
    {/*
        GameObject.Find("background1(Clone)").GetComponent<AudioSource>().Stop();
        GameObject.Find("background2(Clone)").GetComponent<AudioSource>().Stop();
        GameObject.Find("background3(Clone)").GetComponent<AudioSource>().Stop();

        Destroy(GameObject.Find("ClickSound"));
        SceneManager.LoadScene("Main Player Menu");
        */
        SceneManager.LoadScene("Game Menu");
    }
    public void LoadGameLevels()
    {

        SceneManager.LoadScene("Game Levels");
    }
    public void LoadConfigurations()
    {

        SceneManager.LoadScene("Configurations");
    }
    public void LoadEnemies()
    {

        SceneManager.LoadScene("Enemies");
    }
    public void LoadAudio()
    {
        //GameObject.Find("music1(Clone)").GetComponent<AudioSource>().Stop();
        //GameObject.Find("music2(Clone)").GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Audio");
    }
    public void LoadBackground()
    {

        SceneManager.LoadScene("Background");
    }
    public void LoadBronze()
    {

        SceneManager.LoadScene("Game Levels Bronze");
    }
    public void LoadSilver()
    {

        SceneManager.LoadScene("Game Levels Silver");
    }
    public void LoadGold()
    {

        SceneManager.LoadScene("Game Levels Gold");
    }
    public void PlaySound()
    {
        AudioSource click = GameObject.Find("ClickSound").GetComponent<AudioSource>();
        DontDestroyOnLoad(click);
        click.Play();
    }
}
