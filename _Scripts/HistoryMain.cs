using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HistoryMain : MonoBehaviour
{
    /// <summary>
    /// Used to display login history
    /// </summary>

    string fullList;

    void Start()
    {
        fullList = "";

        //If user is admin, display all info
        if (UserValidation.userList[UserValidation.activeUserIndex].isAdmin)
        {
            //Traverses through list of users
            for (int i = 0; i < UserValidation.userList.Count; i++)
            {
                fullList += ("User: " + UserValidation.userList[i].username + "\n");
                fullList += ("Status: " + UserValidation.userList[i].status + "\n");
                DisplayUserLog(i);
                fullList += "\n";
            }
        }
        //otherwise display only user info
        else
        {
            DisplayUserLog(UserValidation.activeUserIndex);
        }


        GameObject.Find("UserLogContent").GetComponent<Text>().text = fullList;
    }

    //Displays all login info of user index n
    void DisplayUserLog(int n)
    {
        for (int i = 0; i < UserValidation.userList[n].activityList.Count; i++)
        {
            fullList += ("Date/Time: " + UserValidation.userList[n].activityList[i].dateTime + "\n");
            fullList += ("Time Elapsed: " + Mathf.Floor(UserValidation.userList[n].activityList[i].timeElapsed / 60).ToString("00") + ":" + Mathf.Floor(UserValidation.userList[n].activityList[i].timeElapsed % 60).ToString("00") + "\n");
        }
    }

    void Update()
    {
        //updates time spent logged in
        UserValidation.timeElapsed += Time.deltaTime;
    }
}
