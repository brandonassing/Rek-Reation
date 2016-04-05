using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Stores info from one login session
/// </summary>
[Serializable]
public class ActivityInfo
{
    public string dateTime;
    public float timeElapsed;

    /// <summary>
    /// instantiates info based on parameters
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="timeElapsed"></param>
    public ActivityInfo(string dateTime, float timeElapsed)
    {
        this.dateTime = dateTime;
        this.timeElapsed = timeElapsed;
    }
}
