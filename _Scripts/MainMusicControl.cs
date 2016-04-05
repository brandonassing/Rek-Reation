using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MainMusicControl : MonoBehaviour
{
    /// <summary>
    /// used to control main menu music
    /// </summary>

    public static GameObject[] music = new GameObject[2];
    public GameObject[] musicPrefab;

    public Dropdown dropDownMusic;
    public Slider vol;
    public static float volLevel = 1;

    void Start()
    {
        //if music isn't instantiated yet, instantiate prefabs
        if (music[0] == null)
        {
            music[0] = Instantiate(musicPrefab[0]) as GameObject;
            music[1] = Instantiate(musicPrefab[1]) as GameObject;

            DontDestroyOnLoad(music[0]);
            DontDestroyOnLoad(music[1]);

            music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().Play();
            music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().loop = true;
            music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().volume = volLevel;
        }
        //otherwise assign prefabs clones
        else
        {
            music[0] = GameObject.Find("music1(Clone)");
            music[1] = GameObject.Find("music2(Clone)");

            if (!music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().isPlaying)
            {
                music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().Play();
                music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().loop = true;
                music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().volume = volLevel;
            }
        }

        //make user input consistent
        dropDownMusic.value = UserValidation.userList[UserValidation.activeUserIndex].musicChoice;
        vol.value = volLevel;

        dropDownMusic.onValueChanged.AddListener(SetMusic);
        vol.onValueChanged.AddListener(ChangeVolume);
    }

    //called when user selects music from drop down
    public void SetMusic(int value)
    {
        StopLastSongBackground();
        UserValidation.userList[UserValidation.activeUserIndex].musicChoice = dropDownMusic.value;
        UserValidation.Save();
        music[dropDownMusic.value].GetComponent<AudioSource>().Play();
        music[dropDownMusic.value].GetComponent<AudioSource>().loop = true;
        music[dropDownMusic.value].GetComponent<AudioSource>().volume = vol.value;
    }

    //Stops current song from playing
    private void StopLastSongBackground()
    {
        music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().Stop();
    }

    //Called when user changes volume
    public void ChangeVolume(float value)
    {
        volLevel = vol.value;
        //if volume is 0 and music isn't playing, play music
        if (!music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().isPlaying)
        {
            music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().Play();
        }
        music[UserValidation.userList[UserValidation.activeUserIndex].musicChoice].GetComponent<AudioSource>().volume = volLevel;
    }

}
