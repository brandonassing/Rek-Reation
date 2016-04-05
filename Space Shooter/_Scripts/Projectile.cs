using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private WeaponType _type;
    public WeaponType type
    {
        get
        {
            return (_type);
        }
        set
        {
            SetType(value);
        }
    }

    public AudioSource shot;

    void Awake()
    {
        switch (MusicControl.laserValD) {
            case 0:
                shot = GameObject.Find("Shot1").GetComponent<AudioSource>();
                break;
            case 1:
                shot = GameObject.Find("Shot2").GetComponent<AudioSource>();
                break;
            case 2:
                shot = GameObject.Find("Shot3").GetComponent<AudioSource>();
                break;
            default:
                shot = GameObject.Find("Shot1").GetComponent<AudioSource>();
                break;
        }
        
        shot.Play();
        shot.volume = MusicControl.laserValS;
        InvokeRepeating("CheckOffScreen", 2f, 2f);
    }

    public void SetType(WeaponType eType)
    {
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefintion(_type);
        GetComponent<Renderer>().material.color = def.projectileColor;
    }

    void CheckOffScreen()
    {
        if (Utils.ScreenBoundsCheck(GetComponent<Collider>().bounds, BoundsTest.offScreen) != Vector3.zero)
        {
            Destroy(this.gameObject);
        }
    }

}
