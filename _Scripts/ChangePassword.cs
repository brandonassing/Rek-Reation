using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangePassword : MonoBehaviour {

    /// <summary>
    /// Used to chagne users' password
    /// </summary>

    public InputField changePasswordIN;
    string password;
    public GameObject passwordText;
    float displayTime = 2.5f;
    bool changed, active;
   
    void Start()
    {
        //Reset text
        passwordText.SetActive(false);
        changed = false;
        active = false;
    }

    //Stores input from input field
    public void StoreInput(string value)
    {
        active = true;
        password = value;
    }

    //Changes password if entered password is valid
    public void Submit()
    {
        //password can't be null or current password
        if (password == null || password == "" || password == UserValidation.userList[UserValidation.activeUserIndex].password)
        {
            passwordText.GetComponent<Text>().text = "Invalid Password";
            passwordText.GetComponent<Text>().color = Color.red;
            passwordText.SetActive(true);
            displayTime = 2.5f;
            changed = false;
        }
        //Valid password
        else
        {
            //Store password in user account
            UserValidation.userList[UserValidation.activeUserIndex].password = password;
            UserValidation.Save();

            changePasswordIN.text = "";
            passwordText.GetComponent<Text>().text = "Password Changed";
            passwordText.GetComponent<Text>().color = Color.green;
            passwordText.SetActive(true);
            displayTime = 2.5f;
            changed = true;
        }
                
    }

    //Called the first time user logs in
    public void SubmitFirst()
    {
        Submit();
        //If password change is successful loads main menu
        if (changed)
        {
            SceneManager.LoadScene("Main Player Menu");
            UserValidation.userList[UserValidation.activeUserIndex].status = "NORMAL";
            UserValidation.Save();
        }
    }

    void Update()
    {
        //enter button functionality
        if (active)
        {
            if (Input.GetKeyDown("return"))
            {
                if (UserValidation.userList[UserValidation.activeUserIndex].status == "NORMAL")
                {
                    Submit();
                }
                else
                {
                    SubmitFirst();
                }
            }
            
        }

        //Used for password feedback
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            passwordText.SetActive(false);
        }
    }
}
