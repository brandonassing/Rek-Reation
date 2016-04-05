using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Extends user, only one admin exists
/// </summary>
[Serializable]
public class Admin : User { 

    /// <summary>
    /// instantiates admin user based on parameters
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="status"></param>

    public Admin(string username, string password, string status)
    {
        this.username = username;
        this.password = password;
        this.status = status;
        isAdmin = true;
    }
}
