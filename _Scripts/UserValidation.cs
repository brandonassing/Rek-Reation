using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UserValidation : MonoBehaviour
{
    /// <summary>
    /// Used to log user in and check validation
    /// </summary>
    public InputField userIN, passIN;
    public EventSystem system;
    string username, password;
    //List of users; index corresponds to userlist
    public static List<int> numTrials = new List<int>();
    public static int activeUserIndex;

    float displayTime = 2.5f;

    public static string dateTime;
    public static float timeElapsed;

    public GameObject clickSoundPrefab;
    public static GameObject clickSound;
    public AudioSource loginMusic;

    public GameObject blockedGO, invalidGO;

    //List of users
    public static List<User> userList = new List<User>();

    void Awake()
    {
        //Used for button press sound
        if (clickSound == null)
        {
            clickSound = Instantiate(clickSoundPrefab) as GameObject;
            DontDestroyOnLoad(clickSound);
        }
    }
    
    void Start()
    {
        userIN = GameObject.Find("Username").GetComponent<InputField>();
        passIN = GameObject.Find("Password").GetComponent<InputField>();

        blockedGO.SetActive(false);
        invalidGO.SetActive(false);

        timeElapsed = 0;

        //Load user data
        Load();

        //If first time in system, make admin account
        if (userList.Count == 0)
        {
            userList.Add(new Admin("admin", "admin", "NORMAL"));
            numTrials.Add(3);
        }

        //loop login music
        loginMusic.Play();
        loginMusic.loop = true;

        //Save user data
        Save();
    }

    void Update()
    {
        //Controls enter button functionality
        if (Input.GetKeyDown("return"))
        {
            ReadInputs();
        }
        //if tab is pressed, go to next input field
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
        }

        //Used for invalid text feedback
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            invalidGO.SetActive(false);
            blockedGO.SetActive(false);
        }
    }

    //Clear password field (called on username input)
    public void ClearPasswordField()
    {
        passIN.text = "";
    }

    //stores input from username and password input fields
    public void ReadInputs()
    {
        username = userIN.text;
        password = passIN.text;
        Validate();
    }

    //check login info
    void Validate()
    {
        int index = userList.FindIndex(user => user.username == username);

        //if user exists...
        if (index >= 0)
        {
            //if user not blocked...
            if (numTrials[index] > 0)
            {
                //if user is normal and password is correct
                if (userList[index].password == password && userList[index].status == "NORMAL")
                {
                    numTrials[index] = 3;
                    activeUserIndex = index;
                    dateTime = DateTime.Now.ToString();
                    Save();
                    SceneManager.LoadScene("Main Player Menu");
                }
                //if user is new and password is correct
                else if (userList[index].password == password && userList[index].status == "NEW")
                {
                    numTrials[index] = 3;
                    activeUserIndex = index;
                    dateTime = DateTime.Now.ToString();
                    Save();
                    //New users must change password on login
                    SceneManager.LoadScene("New User");
                }
                else
                {
                    //Only decrease numTrials for non-admin
                    if (index != 0)
                    {
                        numTrials[index]--;
                    }
                    //if user is blocked
                    if (numTrials[index] <= 0)
                    {
                        invalidGO.SetActive(false);
                        userList[index].status = "BLOCKED";
                        blockedGO.SetActive(true);
                        displayTime = 2.5f;
                        Save();
                    }
                    //if wrong password
                    else
                    {
                        invalidGO.SetActive(true);
                        displayTime = 2.5f;
                    }
                }
            }
            //if user blocked
            else
            {
                invalidGO.SetActive(false);
                blockedGO.SetActive(true);
                displayTime = 2.5f;
            }
        }
        //if user does not exist
        else
        {
            invalidGO.SetActive(true);
            displayTime = 2.5f;
        }
    }

    //Saves user info to text file
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/userAccount.txt");
        UserAccount data = new UserAccount();

        data.users.Clear();
        data.trials.Clear();
        data.users.AddRange(userList);
        data.trials.AddRange(numTrials);
        bf.Serialize(file, data);
        file.Close();
    }

    //Loads user info from file
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/userAccount.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/userAccount.txt", FileMode.Open);
            UserAccount data = (UserAccount)bf.Deserialize(file);
            file.Close();

            userList.Clear();
            numTrials.Clear();
            userList.AddRange(data.users);
            numTrials.AddRange(data.trials);
        }
    }

}

//Used to save user info to file
[Serializable]
public class UserAccount
{
    public List<int> trials = new List<int>();
    public List<User> users = new List<User>();
}