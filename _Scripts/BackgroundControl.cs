using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundControl : MonoBehaviour
{
    /// <summary>
    /// Controls main menu background and saves users input
    /// </summary>
    
    public GameObject background;
    public GameObject displayBack;
    public Material[] listMats;
    public Dropdown dropDownBack;

    void Start()
    {
        //Makes user input consistent between scene changes
        background.GetComponent<Renderer>().material = listMats[UserValidation.userList[UserValidation.activeUserIndex].backgroundChoice];

        //Prevents null reference exception
            if(SceneManager.GetActiveScene().name == "Main Player Menu")
        {
            dropDownBack.value = UserValidation.userList[UserValidation.activeUserIndex].backgroundChoice;
            displayBack.GetComponent<Renderer>().material = listMats[dropDownBack.value];
        }
    }

    //Sets the background display preview box
    public void SetBackgroundChoice()
    {
        displayBack.GetComponent<Renderer>().material = listMats[dropDownBack.value];
    }

    //Sets the game background
    public void SetBackground()
    {
        UserValidation.userList[UserValidation.activeUserIndex].backgroundChoice = dropDownBack.value;
        background.GetComponent<Renderer>().material = listMats[UserValidation.userList[UserValidation.activeUserIndex].backgroundChoice];
        UserValidation.Save();
    }

}
