using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{

    /// <summary>
    /// Used to control/save sound settings
    /// </summary>

    private static MusicControl instanceRef;

    public AudioSource[] lasers = new AudioSource[3];
    public AudioSource[] explosions = new AudioSource[3];
    public AudioSource[] wins = new AudioSource[2];

    public static GameObject[] backgroundMusic = new GameObject[3];
    public GameObject[] backgroundMusicPrefab;
    public Dropdown backD;
    public Slider backS;
    static float backSVal = 0;
    static int lastBackVal = 0;

    static public int laserValD = 0;
    public Dropdown laserD;
    public Slider laserS;
    static public float laserValS = 1;

    static public int expValD = 0;
    public Dropdown expD;
    public Slider expS;
    static public float expValS = 1;

    static public int winValD = 0;
    public Dropdown winD;
    public Slider winS;
    static public float winValS = 1;

    private static GameObject backgroundRef;


    void Start()
    {
        //Creates background audio source objects if not made already
        if (backgroundMusic[0] == null)
        {
            backgroundMusic[0] = Instantiate(backgroundMusicPrefab[0]) as GameObject;
            backgroundMusic[1] = Instantiate(backgroundMusicPrefab[1]) as GameObject;
            backgroundMusic[2] = Instantiate(backgroundMusicPrefab[2]) as GameObject;

            DontDestroyOnLoad(backgroundMusic[0]);
            DontDestroyOnLoad(backgroundMusic[1]);
            DontDestroyOnLoad(backgroundMusic[2]);
        }
        //If background audio sources already made, assigns them
        else
        {
            backgroundMusic[0] = GameObject.Find("background1(Clone)");
            backgroundMusic[1] = GameObject.Find("background2(Clone)");
            backgroundMusic[2] = GameObject.Find("background3(Clone)");
        }
        
        //Sets dropdown/slider values to previous
        backD.value = lastBackVal;
        backS.value = backSVal;

        laserD.value = laserValD;
        laserS.value = laserValS;

        expD.value = expValD;
        expS.value = expValS;

        winD.value = winValD;
        winS.value = winValS;

        //Add listeners
        backD.onValueChanged.AddListener(PlaySongBackground);
        backS.onValueChanged.AddListener(ChangeSongVolumeBackground);

        laserD.onValueChanged.AddListener(SetLaserSound);
        laserS.onValueChanged.AddListener(SetLaserVolume);

        expD.onValueChanged.AddListener(SetExplosionSound);
        expS.onValueChanged.AddListener(SetExplosionVolume);

        winD.onValueChanged.AddListener(SetWinMusic);
        winS.onValueChanged.AddListener(SetWinVolume);
    }

    //Plays background music
    public void PlaySongBackground(int value)
    {
        StopLastSongBackground();
        lastBackVal = backD.value;
        backgroundMusic[backD.value].GetComponent<AudioSource>().Play();
        backgroundMusic[backD.value].GetComponent<AudioSource>().volume = backS.value;
    }

    //Stops previous song for song change
    public void StopLastSongBackground()
    {
        backgroundMusic[lastBackVal].GetComponent<AudioSource>().Stop();
    }

    //Changes song volume and starts song if not playing
    public void ChangeSongVolumeBackground(float value)
    {
        backSVal = backS.value;
        if (!backgroundMusic[lastBackVal].GetComponent<AudioSource>().isPlaying)
        {
            backgroundMusic[lastBackVal].GetComponent<AudioSource>().Play();
        }
        backgroundMusic[lastBackVal].GetComponent<AudioSource>().volume = backSVal;
    }

    //Allows user to select laser sound effect
    public void SetLaserSound(int value)
    {
        laserValD = laserD.value;
        laserValS = laserS.value;
        lasers[laserValD].Play();
    }
    //Allows user to select laser sound effect volume
    public void SetLaserVolume(float value)
    {
        laserValS = laserS.value;
    }

    //Allows user to select explosion sound effect
    public void SetExplosionSound(int value)
    {
        expValD = expD.value;
        expValS = expS.value;
        explosions[expValD].Play();
    }
    //Allows user to select explosion sound effect volume
    public void SetExplosionVolume(float value)
    {
        expValS = expS.value;
    }

    //Allows user to select level up fanfare
    public void SetWinMusic(int value)
    {
        winValD = winD.value;
        winValS = winS.value;
        wins[winValD].Play();
    }
    //Allows user to select level up fanfare volume
    public void SetWinVolume(float value)
    {
        winValS = winS.value;
    }


}
