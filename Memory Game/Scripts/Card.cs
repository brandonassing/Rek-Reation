using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{

    /// <summary>
    /// Controls card flips and On-Click call in main
    /// </summary>

    public int value;
    bool rotated;
    public GameObject M;

    public AudioSource click;

    private int counter;

    void Awake()
    {
        M = GameObject.Find("Main Camera");
    }

    void Start()
    {
        counter = 17;
    }

    //Calls RotateFull
    public void Rotate()
    {
        Invoke("RotateFull", 0.03f);
    }

    //Rotates until flipped
    public void RotateFull()
    {
        this.gameObject.transform.Rotate(new Vector3(0, 0, 10));
        if (counter == 0)
        {
            counter = 17;
            CancelInvoke("RotateFull");
        }
        else
        {
            counter--;
            Invoke("RotateFull", 0.03f);
        }
    }

    //Called when card is pressed
    void OnMouseUpAsButton()
    {
        if (MainMG.finished)
        {
            click.Play();
            M.GetComponent<MainMG>().CardPressed(this.gameObject);
        }
    }


}
