using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CreateUser : MonoBehaviour {

    /// <summary>
    /// Used by admin to create new users
    /// </summary>

    public InputField createUserIN;
    string username;
    public GameObject usernameText;
    float displayTime = 2.5f;

    bool active;

    void Start()
    {
        //reset text
        usernameText.SetActive(false);
        active = false;
    }

    //Stores username from input field
    public void StoreInput(string value)
    {
        active = true;
        username = value;
    }

    public void Submit()
    {
        //compiles list of existing usernames to check validation
        List<string> existingUsernames = new List<string>();
        for (int i = 0; i < UserValidation.userList.Count; i++)
        {
            existingUsernames.Add(UserValidation.userList[i].username);
        }

        //invalid if username is null
        if (username == null || username == "")
        {
            usernameText.GetComponent<Text>().text = "Invalid Username";
            usernameText.GetComponent<Text>().color = Color.red;
            usernameText.SetActive(true);
            displayTime = 2.5f;
        }
        //invalid if username already exists
        else if (existingUsernames.Contains(username))
        {
            usernameText.GetComponent<Text>().text = "Username Already Exists";
            usernameText.GetComponent<Text>().color = Color.red;
            usernameText.SetActive(true);
            displayTime = 2.5f;
        }
        //valid username
        else
        {
            //add to list of users
            UserValidation.userList.Add(new User(username, username, "NEW"));
            UserValidation.numTrials.Add(3);
            UserValidation.Save();

            createUserIN.text = "";
            usernameText.GetComponent<Text>().text = "User Created";
            usernameText.GetComponent<Text>().color = Color.green;
            usernameText.SetActive(true);
            displayTime = 2.5f;
        }
        active = false;
    }

    void Update()
    {
        //enter button functionlity
        if (active)
        {
            if (Input.GetKeyDown("return"))
            {
                Submit();
            }
        }

        //used for feedback text
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            usernameText.SetActive(false);
        }
    }
}
