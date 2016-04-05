using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static public Player S;
    

    public float gameRestartDelay = 2f;

    public AudioSource explosion;
    public Text scoreGT;
    public int score;

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public bool __________;

    public Bounds bounds;

    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate fireDelegate;

    public GameObject lastTriggerGo = null;

    [SerializeField]
    private float _shieldLevel = 1;

    public Weapon[] weapons;

    void Awake()
    {
        S = this;
        bounds = Utils.CombineBoundsOfChildren(this.gameObject);
    }

    void Start()
    {
        bounds = Utils.CombineBoundsOfChildren(this.gameObject);

        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "Your Score: 0";
        ClearWeapons();
        weapons[0].SetType(WeaponType.blaster);
    }

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
        
        bounds.center = transform.position;

        Vector3 off = Utils.ScreenBoundsCheck(bounds, BoundsTest.onScreen);
        if (off != Vector3.zero)
        {
            pos -= off;
            transform.position = pos;
        }

        if (Input.GetAxis("Jump") == 1 && fireDelegate != null)
        {
            fireDelegate();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject go = Utils.FindTaggedParent(other.gameObject);
        if (go != null)
        {
            if (go == lastTriggerGo)
            {
                return;
            }
            lastTriggerGo = go;

            if (go.tag == "Enemy")
            {
                shieldLevel--;
                Destroy(go);
                Main.enemiesActive--;
            }
            else if (go.tag == "ProjectileEnemy")
            {
                shieldLevel--;
                Destroy(go);
            }
            else if (go.tag == "PowerUp")
            {
                AbsorbPowerUp(go);
            }
            else
            {

                print("Triggered: " + go.name);
            }
        }
        else
        {
            print("Triggered: " + other.gameObject.name);
        }
    }

    //Applies power up
    public void AbsorbPowerUp(GameObject go)
    {
        PowerUp pu = go.GetComponent<PowerUp>();
        switch (pu.type)
        {
            case WeaponType.shield:
                shieldLevel++;
                break;
            default:
                if (pu.type == weapons[0].type)
                {
                    Weapon w = GetEmptyWeaponSlot();
                    if (w != null)
                    {
                        w.SetType(pu.type);
                    }
                }
                else
                {
                    ClearWeapons();
                    weapons[0].SetType(pu.type);
                }
                break;
        }
        pu.AbsorbedBy(this.gameObject);
    }

    //Returns an available weapon slot
    Weapon GetEmptyWeaponSlot()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].type == WeaponType.none)
            {
                return (weapons[i]);
            }
        }
        return (null);
    }

    //Removes weapons
    void ClearWeapons()
    {
        foreach (Weapon w in weapons)
        {
            w.SetType(WeaponType.none);
        }
    }

    public float shieldLevel
    {
        get
        {
            return (_shieldLevel);
        }
        set
        {
            _shieldLevel = Mathf.Min(value, 4);
            if (value < 0)
            {
                explosion.Play();
                Destroy(this.gameObject);
                Main.S.DelayedDied(gameRestartDelay);
            }
        }
    }

    //Used to update player score and high score
    public void increaseScore(int inc)
    {
        score += inc;
        scoreGT.text = "Your Score: " + score.ToString();
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
