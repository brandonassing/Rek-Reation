using UnityEngine;
using System.Collections;

public class Enemy_3 : Enemy
{
    public Vector3[] points;
    public float birthTime;
    public float lifeTime = 10;

    static public bool weaponActive = false;
    public Weapon weapon;

    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate fireDelegate;


    void Start()
    {
        points = new Vector3[3];
        points[0] = pos;

        float xMin = Utils.camBounds.min.x + Main.S.enemySpawnPadding;
        float xMax = Utils.camBounds.max.x - Main.S.enemySpawnPadding;

        Vector3 v;
        v = Vector3.zero;
        v.x = Random.Range(xMin, xMax);
        v.y = Random.Range(Utils.camBounds.min.y, 0);
        points[1] = v;

        v = Vector3.zero;
        v.y = pos.y;
        v.x = Random.Range(xMin, xMax);
        points[2] = v;

        birthTime = Time.time;
        
        if (weaponActive)
        {
            weapon.SetType(WeaponType.spread);
            Invoke("Fire", 3f);
        }
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = EnemySettings.getColor(3);
            originalColors[i] = EnemySettings.getColor(3);
        }
        ID = 3;
    }

    void Fire()
    {
        weapon.EnemyFire();
        Invoke("Fire", 2f);
    }

    public override int getScore()
    {
        return EnemySettings.getScore(3);
    }

    public override void Move()
    {

        float u = (Time.time - birthTime) / lifeTime;

        if (u > 1)
        {
            Main.enemiesActive--;
            Destroy(this.gameObject);
            return;
        }

        Vector3 p01, p12;
        p01 = (1 - u) * points[0] + u * points[1];
        p12 = (1 - u) * points[1] + u * points[2];
        pos = (1 - u) * p01 + u * p12;
    }
}
