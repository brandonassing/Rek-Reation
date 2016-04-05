using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


/// <summary>
/// stores info for each user
/// </summary>
[Serializable]
public class User
{
    public string username;
    public string password;
    public bool isAdmin;
    public string status;
    public int musicChoice, backgroundChoice;

    //list of games played
    public List<GameInfo> gameList = new List<GameInfo>();
    //list of logins
    public List<ActivityInfo> activityList = new List<ActivityInfo>();

    /// <summary>
    /// Default constructor
    /// </summary>
    public User()
    {
        username = "";
        password = "";
        isAdmin = false;
        status = "NORMAL";

        musicChoice = 0;
        backgroundChoice = 0;
    }

    /// <summary>
    /// Instantiates User based on parameters
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="status"></param>
    public User(string username, string password, string status)
    {
        this.username = username;
        this.password = password;
        this.status = status;
        isAdmin = false;

        musicChoice = 0;
        backgroundChoice = 0;
    }

    //Adds to the list of activities
    public void AddActivity(string dateTime, float timeElapsed)
    {
        activityList.Add(new ActivityInfo(dateTime, timeElapsed));
    }

    //Adds to the list of games
    public void AddGame(string type, int score, string playerName, string dateTime)
    {
        gameList.Add(new GameInfo(type, score, playerName, dateTime));
    }

    //Addes to the list of games (for space shooter)
    public void AddGame(string type, int score, string playerName, string dateTime, string gameLevel)
    {
        gameList.Add(new GameInfo(type, score, playerName, dateTime, gameLevel));
    }
}
