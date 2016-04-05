using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public float rotationsPerSecond = 0.1f;
    public bool __________;
    public int levelShown = 0;
    

    void Update () {
        int currLevel = Mathf.FloorToInt(Player.S.shieldLevel);
        if (levelShown!= currLevel)
        {
            levelShown = currLevel;
            Material mat = this.GetComponent<Renderer>().material;
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }
        float rZ = (rotationsPerSecond * Time.time * 360) % 360f;

        //TRY ROTATING X AND Y

        transform.rotation = Quaternion.Euler(rZ * 30, rZ*30, rZ);
	}
}
