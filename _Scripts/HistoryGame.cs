using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HistoryGame : MonoBehaviour
{
    /// <summary>
    /// Used to display all game history
    /// </summary>
    
    void Start()
    {
        string fullList;
        GameObject.Find("Title").GetComponent<Text>().text = MainSceneManager.gameHistoryType;

        fullList = "";
        
        for (int i = 0; i < UserValidation.userList.Count; i++)
        {
            //Display each username
            fullList += ("User: " + UserValidation.userList[i].username + "\n");

            //Traverses through each users list of games played
            for (int j = 0; j < UserValidation.userList[i].gameList.Count; j++)
            {
                //only displays games that are the same type as the history button selected
                if (UserValidation.userList[i].gameList[j].type == MainSceneManager.gameHistoryType)
                {
                    fullList += ("Date/Time: " + UserValidation.userList[i].gameList[j].dateTime + "\n");
                    fullList += ("Score: " + UserValidation.userList[i].gameList[j].score + "\n");

                    //If the game played was space shooter display game level as well
                    if (UserValidation.userList[i].gameList[j].type == "Space Shooter")
                    {
                        fullList += ("Game Level: " + UserValidation.userList[i].gameList[j].gameLevel + "\n");
                    }
                }
            }
            fullList += "\n";
        }

        GameObject.Find("UserLogContent").GetComponent<Text>().text = fullList;
    }

    void Update()
    {
        //Updates time spent logged in
        UserValidation.timeElapsed += Time.deltaTime;
    }
}
