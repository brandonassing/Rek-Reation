using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeleteUser : MonoBehaviour {

    /// <summary>
    /// Used by admin to delete users
    /// </summary>

    public InputField deleteUserIN;
    public GameObject userList;
    string username;
    public GameObject deleteText;
    float displayTime = 2.5f;

    bool active;

    void Start()
    {
        //resets text
        deleteText.SetActive(false);
        userList.SetActive(false);
        active = false;
    }

    //Displays list of all users
    public void DisplayList()
    {
        string fullList = "";
        userList.SetActive(true);
        for (int i = 1; i < UserValidation.userList.Count; i++)
        {
            fullList += (UserValidation.userList [i].username+ "\n");
        }
        GameObject.Find("UserListContent").GetComponent<Text>().text = fullList;
    }

    //stores username from input field
    public void StoreInput(string value)
    {
        active = true;
        username = value;
    }

    public void Submit()
    {
        //compiles list of existing users
        List<string> existingUsernames = new List<string>();
        for (int i = 0; i < UserValidation.userList.Count; i++)
        {
            existingUsernames.Add(UserValidation.userList[i].username);
        }

        //if username entered does not exist
        if (!existingUsernames.Contains(username))
        {
            deleteText.GetComponent<Text>().text = username + " Does Not Exist";
            deleteText.GetComponent<Text>().color = Color.red;
            deleteText.SetActive(true);
            displayTime = 2.5f;
        }

        //can't delete admin
        else if (username == "admin")
        {
            deleteText.GetComponent<Text>().text = "Cannot Delete Admin";
            deleteText.GetComponent<Text>().color = Color.red;
            deleteText.SetActive(true);
            displayTime = 2.5f;
        }

        //remove user
        else
        {
            UserValidation.userList.RemoveAt(existingUsernames.IndexOf(username));
            UserValidation.Save();

            deleteUserIN.text = "";
            deleteText.GetComponent<Text>().text = username + " Deleted";
            deleteText.GetComponent<Text>().color = Color.green;
            deleteText.SetActive(true);
            displayTime = 2.5f;
            DisplayList();
        }
        active = false;
    }   

    void Update()
    {
     //enter button functionality   
        if (active)
        {
            if (Input.GetKeyDown("return"))
            {
                Submit();
            }
        }
        
        //controls feedback text
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            deleteText.SetActive(false);
        }
    }
}
