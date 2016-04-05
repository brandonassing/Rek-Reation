using UnityEngine;
using System.Collections;

public class PowerUpHelp : MonoBehaviour {

    public Vector2 rotMinMax = new Vector2(15, 90);
    public bool __________;
    public WeaponType type;
    public GameObject cube;
    public TextMesh letter;
    public Vector3 rotPerSecond;
    public float birthTime;

    void Awake()
    {
        cube = transform.Find("Cube").gameObject;
        letter = GetComponent<TextMesh>();

        transform.rotation = Quaternion.identity;

            rotPerSecond = new Vector3(Random.Range(rotMinMax.x, rotMinMax.y), Random.Range(rotMinMax.x, rotMinMax.y), Random.Range(rotMinMax.x, rotMinMax.y));
       
        
    }

	void Update () {

        cube.transform.rotation = Quaternion.Euler(rotPerSecond * Time.time);
        /*
       
            Color c = cube.GetComponent<Renderer>().material.color;
       // c.a = 1f - u;
        cube.GetComponent<Renderer>().material.color = c;
        c = letter.color;
       // c.a = 1f - (u * 0.5f);
        letter.color = c;
        */

    }

    public void SetType(WeaponType wt)
    {
        WeaponDefinition def = Main.GetWeaponDefintion(wt);
        cube.GetComponent<Renderer>().material.color = def.color;
        //letter.color = def.color;
        letter.text = def.letter;
        type = wt;
    }

   
}
