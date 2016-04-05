using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Stores info from each game session
/// </summary>
[Serializable]
public class GameInfo
{
    public string type;
    public int score;
    public string playerName;
    public string dateTime;
    public string gameLevel;

    /// <summary>
    /// Instantiates game history from parameters
    /// </summary>
    /// <param name="type"></param>
    /// <param name="score"></param>
    /// <param name="playerName"></param>
    /// <param name="dateTime"></param>
    public GameInfo(string type, int score, string playerName, string dateTime)
    {
        this.type = type;
        this.score = score;
        this.playerName = playerName;
        this.dateTime = dateTime;
    }

    /// <summary>
    /// Instantiates game history from parameters (for space shooter)
    /// </summary>
    /// <param name="type"></param>
    /// <param name="score"></param>
    /// <param name="playerName"></param>
    /// <param name="dateTime"></param>
    /// <param name="gameLevel"></param>
    public GameInfo(string type, int score, string playerName, string dateTime, string gameLevel)
    {
        this.type = type;
        this.score = score;
        this.playerName = playerName;
        this.dateTime = dateTime;
        this.gameLevel = gameLevel;
    }
}
