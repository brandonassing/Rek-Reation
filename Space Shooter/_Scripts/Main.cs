using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    static public Main S;
    public Player H;
    static public Dictionary<WeaponType, WeaponDefinition> W_DEFS;
    bool pause = false;
    public Text pauseGT;
    //public Button quitGame;
    //public Button restartGame;

    public Text timerGT;
    public static float timer;
    public static bool timeStarted = false;

    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemySpawnPadding = 1.5f;

    public AudioSource[] explosion;
    public AudioSource[] winMusic;

    public WeaponDefinition[] weaponDefinitions;
    public GameObject prefabPowerUp;
    public WeaponType[] powerUpFrequency = new WeaponType[] { WeaponType.blaster, WeaponType.blaster, WeaponType.spread, WeaponType.shield };

    public bool __________;

    public WeaponType[] activeWeaponTypes;
    public float enemySpawnRate;

    public int gameLevel, scorePerLevel;
    static public int enemiesActive;
    public bool inactiveEnemy;
    public Text levelGT;
    public Text enemiesKilledGT0, enemiesKilledGT1, enemiesKilledGT2, enemiesKilledGT3, enemiesKilledGT4;
    private int[] enemiesKilled;
    private bool gameOver = false;

    string dateTime;

    void Awake()
    {
        Time.timeScale = 1;
        S = this;
        Utils.SetCameraBounds(this.GetComponent<Camera>());

        enemySpawnRate = 1f / enemySpawnPerSecond;
        Invoke("SpawnEnemy", enemySpawnRate);

        W_DEFS = new Dictionary<WeaponType, WeaponDefinition>();
        foreach (WeaponDefinition def in weaponDefinitions)
        {
            W_DEFS[def.type] = def;
        }

        enemiesKilled = new int[5];
    }

    static public WeaponDefinition GetWeaponDefintion(WeaponType wt)
    {
        if (W_DEFS.ContainsKey(wt))
        {
            return W_DEFS[wt];
        }
        return (new WeaponDefinition());
    }

    void Start()
    {
        dateTime = System.DateTime.Now.ToString();

        Utils.SetCameraBounds(this.GetComponent<Camera>());

        TextSetup();

        activeWeaponTypes = new WeaponType[weaponDefinitions.Length];
        for (int i = 0; i < weaponDefinitions.Length; i++)
        {
            activeWeaponTypes[i] = weaponDefinitions[i].type;
        }
        gameLevel = 0;
        enemiesActive = 0;
        scorePerLevel = 0;

        //Instatiates EnemySettings and GameLevelSettings scripts if not already done
        if (!EnemySettings.wasActivated)
        {
            EnemySettings.InitialSetValues();
        }
        if (!GameLevelSettings.wasActivated)
        {
            GameLevelSettings.InitialSetValues();
        }

        Reset();
    }

    //Used to set up on screen text
    void TextSetup()
    {
        GameObject pauseGO = GameObject.Find("Pause");
        pauseGT = pauseGO.GetComponent<Text>();
        pauseGT.text = "";
        //quitGame.gameObject.SetActive(false);
        //restartGame.gameObject.SetActive(false);

        GameObject levelGO = GameObject.Find("GameLevel");
        levelGT = levelGO.GetComponent<Text>();
        levelGT.text = "Level: " + GetGameLevel();

        timer = 0;
        GameObject timerGO = GameObject.Find("Timer");
        timerGT = timerGO.GetComponent<Text>();
        timerGT.text = "Timer: 00:00";
        timeStarted = true;

        enemiesKilledGT0 = GameObject.Find("Killed1").GetComponent<Text>();
        enemiesKilledGT1 = GameObject.Find("Killed2").GetComponent<Text>();
        enemiesKilledGT2 = GameObject.Find("Killed3").GetComponent<Text>();
        enemiesKilledGT3 = GameObject.Find("Killed4").GetComponent<Text>();
        enemiesKilledGT4 = GameObject.Find("Killed5").GetComponent<Text>();

        UpdateEnemyKilled();
    }

    void Update()
    {
        //Checks to see if game level should progress
        if (!gameOver)
        {
            if (scorePerLevel >= GameLevelSettings.highestScore[gameLevel])
            {
                winMusic[MusicControl.winValD].Play();
                winMusic[MusicControl.winValD].volume = MusicControl.expValS;

                gameLevel++;
                scorePerLevel = 0;
                if (gameLevel > 2)
                {
                    pauseGT.text = "GAME OVER";
                    gameOver = true;
                    Destroy(H);
                    DelayedDied(4f);
                }
                //Activate shooting enemy on game level GOLD
                if (gameLevel == 2)
                {
                    Enemy_3.weaponActive = true;
                    prefabEnemies[3] = (GameObject)Resources.Load("Enemy_3Fire");
                }
                levelGT.text = "Level: " + GetGameLevel();
            }

            //Updates on screen timer
            if (timeStarted == true)
            {
                timer += Time.deltaTime;
            }
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = Mathf.Floor(timer % 60).ToString("00");
            timerGT.text = "Timer: " + minutes + ":" + seconds;
            /*  if (Input.GetKeyDown("p"))
              {
                  pauseGame();
              }
              */
        }
    }

    //Resets enemies to non-shooters
    void Reset()
    {
        prefabEnemies[3] = (GameObject)Resources.Load("Enemy_3");
        Enemy_3.weaponActive = false;
    }

    public void pauseGame()
    {
        if (pause)
        {
            // UnityEngine.Cursor.visible = false;
            Time.timeScale = 1;
            pauseGT.text = "";
            //    quitGame.gameObject.SetActive(false);
            //    restartGame.gameObject.SetActive(false);
            pause = false;
        }
        else
        {
            //   UnityEngine.Cursor.visible = true;
            Time.timeScale = 0;
            pauseGT.text = "PAUSED";
            //    quitGame.gameObject.SetActive(true);
            //   restartGame.gameObject.SetActive(true);
            pause = true;
        }
    }

    //Used to update game level text
    public string GetGameLevel()
    {
        switch (gameLevel)
        {
            case 0: return "Bronze";
            case 1: return "Silver";
            case 2: return "Gold";
            default: return "Bronze";
        }
    }

    public void SpawnEnemy()
    {
        if (!gameOver)
        {
            //Makes surenumber of enemies on screen does not exceed limit
            if (enemiesActive < GameLevelSettings.maxEnemies[gameLevel])
            {
                int ndx = Random.Range(0, prefabEnemies.Length);

                //Changes random variable if it is an enemy that is set to inactive
                for (int i = 0; i < 5; i++)
                {
                    if (ndx == GameLevelSettings.inactiveEnemies[gameLevel, i])
                    {
                        inactiveEnemy = true;
                        ndx = Random.Range(0, prefabEnemies.Length);
                        i = 0;
                    }
                }

                inactiveEnemy = false;
                GameObject go = Instantiate(prefabEnemies[ndx]) as GameObject;

                Vector3 pos = Vector3.zero;
                float xMin = Utils.camBounds.min.x + enemySpawnPadding;
                float xMax = Utils.camBounds.max.x - enemySpawnPadding;
                pos.x = Random.Range(xMin, xMax);
                pos.y = Utils.camBounds.max.y + enemySpawnPadding;
                go.transform.position = pos;

                enemiesActive++;
            }
            Invoke("SpawnEnemy", enemySpawnRate);
        }
    }

    //Called when enemy dies
    public void ShipDestroyed(Enemy e)
    {
        H.increaseScore(e.getScore());
        scorePerLevel += e.getScore();
        //Used to update enemy kill list
        enemiesKilled[e.ID]++;
        UpdateEnemyKilled();

        explosion[MusicControl.expValD].Play();
        explosion[MusicControl.expValD].volume = MusicControl.expValS;

        if (Random.value <= e.powerUpDropChance)
        {
            int ndx = Random.Range(0, powerUpFrequency.Length);
            WeaponType puType = powerUpFrequency[ndx];

            GameObject go = Instantiate(prefabPowerUp) as GameObject;
            PowerUp pu = go.GetComponent<PowerUp>();
            pu.SetType(puType);

            pu.transform.position = e.transform.position;
        }

        enemiesActive--;
    }

    //Used to update list of enemies killed text
    void UpdateEnemyKilled()
    {
        enemiesKilledGT0.text = "Enemy 1: " + enemiesKilled[0];
        enemiesKilledGT1.text = "Enemy 2: " + enemiesKilled[1];
        enemiesKilledGT2.text = "Enemy 3: " + enemiesKilled[2];
        enemiesKilledGT3.text = "Enemy 4: " + enemiesKilled[3];
        enemiesKilledGT4.text = "Enemy 5: " + enemiesKilled[4];
    }


    //Used for adding to game history
    string gameLevelSTR;
    void GetGameLevelSTR()
    {
        switch (gameLevel)
        {
            case 0:
                gameLevelSTR = "Bronze";
                break;
            case 1:
                gameLevelSTR = "Silver";
                break;
            case 2:
                gameLevelSTR = "Gold";
                break;
            case 3:
                gameLevelSTR = "Gold";
                break;
            default:
                gameLevelSTR = "Bronze";
                break;
        }
    }

    //Used to return to start menu
    public void DelayedDied(float delay)
    {
        Invoke("Died", delay);
    }

    public void Died()
    {
        GetGameLevelSTR();
        UserValidation.userList[UserValidation.activeUserIndex].AddGame("Space Shooter", H.score, UserValidation.userList[UserValidation.activeUserIndex].username, dateTime, gameLevelSTR);
        UserValidation.Save();
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    //Used to restart game
    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }
    public void Restart()
    {
        GetGameLevelSTR();
        UserValidation.userList[UserValidation.activeUserIndex].AddGame("Space Shooter", H.score, UserValidation.userList[UserValidation.activeUserIndex].username, dateTime, gameLevelSTR);
        UserValidation.Save();
        Time.timeScale = 1;
        SceneManager.LoadScene("_Scene_0");
    }
}
