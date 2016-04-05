using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnblockUser : MonoBehaviour
{
    /// <summary>
    /// Used by admin to unblock users
    /// </summary>

    public InputField unblockUserIN;
    public GameObject blockList;
    string username;
    public GameObject unblockText;
    float displayTime = 2.5f;

    bool active;

    void Start()
    {
        //reset text
        unblockText.SetActive(false);
        blockList.SetActive(false);
        active = false;
    }

    //Used to display list of users that are blocked
    public void DisplayList()
    {
        string fullList = "";
        blockList.SetActive(true);
        for (int i = 0; i < UserValidation.userList.Count; i++)
        {
            if (UserValidation.userList[i].status == "BLOCKED")
            {
                fullList += (UserValidation.userList[i].username + "\n");
            }
        }
        GameObject.Find("BlockedListContent").GetComponent<Text>().text = fullList;
    }

    //Stores input of input field
    public void StoreInput(string value)
    {
        active = true;
        username = value;
    }

    public void Submit()
    {
        //compiles list of blocked users and a list of their corresponding indexes
        List<string> blocked = new List<string>();
        List<int> blockedIndex = new List<int>();
        for (int i = 0; i < UserValidation.userList.Count; i++)
        {
            if (UserValidation.userList[i].status == "BLOCKED")
            {
                blocked.Add(UserValidation.userList[i].username);
                blockedIndex.Add(i);
            }
        }

        //If user is not blockeds
        if (!blocked.Contains(username))
        {
            unblockText.GetComponent<Text>().text = username + " Not On Block List";
            unblockText.GetComponent<Text>().color = Color.red;
            unblockText.SetActive(true);
            displayTime = 2.5f;
        }
        //if user is blocked
        else
        {
            //Status changed and password changed to username
            UserValidation.userList[blockedIndex[blocked.IndexOf(username)]].status = "NEW";
            UserValidation.userList[blockedIndex[blocked.IndexOf(username)]].password = username;
            UserValidation.numTrials[blockedIndex[blocked.IndexOf(username)]] = 3;
            UserValidation.Save();

            unblockUserIN.text = "";
            unblockText.GetComponent<Text>().text = username + " Unblocked";
            unblockText.GetComponent<Text>().color = Color.green;
            unblockText.SetActive(true);
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

        //controls text feedback
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            unblockText.SetActive(false);
        }
    }
}