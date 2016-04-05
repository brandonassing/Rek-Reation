using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    /// <summary>
    /// Used to control main menu buttons
    /// </summary>

    public GameObject title;
    public GameObject[] file = new GameObject[5];

    public GameObject[] userAccts = new GameObject[4];
    public GameObject[] changePassword = new GameObject[2];
    public GameObject[] createUser = new GameObject[2];
    public GameObject[] deleteUser = new GameObject[2];
    public GameObject[] unblockUser = new GameObject[2];

    public GameObject[] config = new GameObject[2];
    public GameObject[] background = new GameObject[3];
    public GameObject[] music = new GameObject[2];

    public GameObject[] shoot = new GameObject[3];
    public GameObject[] memory = new GameObject[3];
    public GameObject[] rps = new GameObject[3];
    public GameObject[] apple = new GameObject[3];

    void Awake()
    {
        SetAllInactive();
        UserValidation.Load();
    }

    void Update()
    {
        //Used for login time elapsed
        UserValidation.timeElapsed += Time.deltaTime;
    }

    //Sets all non-primary buttons/UI to inactive
    void SetAllInactive()
    {
        //Disable file UI
        for (int i = 0; i < file.Length; i++)
        {
            file[i].SetActive(false);
        }
        for (int i = 0; i < userAccts.Length; i++)
        {
            userAccts[i].SetActive(false);
        }
        ResetUserAccts();

        for (int i = 0; i < config.Length; i++)
        {
            config[i].SetActive(false);
        }

        for (int i = 0; i < background.Length; i++)
        {
            background[i].SetActive(false);
        }
        for (int i = 0; i < music.Length; i++)
        {
            music[i].SetActive(false);
        }

        //*************************************************
        //Disable space shooter UI
        for (int i = 0; i < shoot.Length; i++)
        {
            shoot[i].SetActive(false);
        }
        //Disable mini-game UI
        for (int i = 0; i < memory.Length; i++)
        {
            memory[i].SetActive(false);
            rps[i].SetActive(false);
            apple[i].SetActive(false);
        }
    }

    //==========================PRIMARY BUTTON MENUS===========================================================================================
    //Opens file menu
    public void OpenFile()
    {
        SetAllInactive();
        foreach (GameObject b in file)
        {
            b.SetActive(true);
        }
    }
    //Opens space shooter menu
    public void OpenShoot()
    {
        SetAllInactive();
        foreach (GameObject b in shoot)
        {
            b.SetActive(true);
        }
    }
    //Opens memory game menu
    public void OpenMemory()
    {
        SetAllInactive();
        foreach (GameObject b in memory)
        {
            b.SetActive(true);
        }
    }
    //Opens rock paper scissors menu
    public void OpenRPS()
    {
        SetAllInactive();
        foreach (GameObject b in rps)
        {
            b.SetActive(true);
        }
    }
    //Opens apple shooter menu
    public void OpenApple()
    {
        SetAllInactive();
        foreach (GameObject b in apple)
        {
            b.SetActive(true);
        }
    }

    //==========================USER ACCOUNT MENUS===========================================================================================
    //Open main user accounts menu
    public void OpenUserAccounts()
    {
        foreach (GameObject b in config)
        {
            b.SetActive(false);
        }
        userAccts[0].SetActive(true);
        if (UserValidation.userList[UserValidation.activeUserIndex].isAdmin)
        {
            foreach (GameObject b in userAccts)
            {
                b.SetActive(true);
            }
        }
    }

    //Disables UI for user accounts
    void ResetUserAccts()
    {
        foreach (GameObject b in changePassword)
        {
            b.SetActive(false);
        }
        foreach (GameObject b in createUser)
        {
            b.SetActive(false);
        }
        foreach (GameObject b in deleteUser)
        {
            b.SetActive(false);
        }
        foreach (GameObject b in unblockUser)
        {
            b.SetActive(false);
        }

    }

    //Opens change password menu
    public void OpenPassword()
    {
        ResetUserAccts();
        foreach (GameObject b in changePassword)
        {
            b.SetActive(true);
        }
    }
    //Opens create user menu
    public void OpenCreateUser()
    {
        ResetUserAccts();
        foreach (GameObject b in createUser)
        {
            b.SetActive(true);
        }
    }
    //Opens delete user menu
    public void OpenDeleteUser()
    {
        ResetUserAccts();
        foreach (GameObject b in deleteUser)
        {
            b.SetActive(true);
        }
    }
    //Opens unblock user menu
    public void OpenUnblockUser()
    {
        ResetUserAccts();
        foreach (GameObject b in unblockUser)
        {
            b.SetActive(true);
        }
    }

    //==================CONFIGURATIONS MENUS============================================================================================

    //Opens main configurations menu
    public void OpenConfigurations()
    {
        foreach (GameObject b in userAccts)
        {
            b.SetActive(false);
        }
        foreach (GameObject b in music)
        {
            b.SetActive(false);
        }
        foreach (GameObject b in background)
        {
            b.SetActive(false);
        }
        ResetUserAccts();
        foreach (GameObject b in config)
        {
            b.SetActive(true);
        }
    }
    //Opens background settings
    public void OpenBackground()
    {
        foreach (GameObject b in music)
        {
            b.SetActive(false);
        }

        foreach (GameObject b in background)
        {
            b.SetActive(true);
        }
    }
    //Opens audio settings
    public void OpenAudio()
    {
        foreach (GameObject b in background)
        {
            b.SetActive(false);
        }

        foreach (GameObject b in music)
        {
            b.SetActive(true);
        }
    }

}