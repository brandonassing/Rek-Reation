using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Parallax : MonoBehaviour
{

    /// <summary>
    /// Used for background control
    /// </summary>

    public GameObject poi;
    public GameObject[] panels;

    public float scrollSpeed = -20f;
    public float motionMult = 0.25f;

    private float panelHt;
    private float depth;

    public GameObject background;
    static public int backgroundChoice = 0;
    public GameObject displayBack;
    public Material[] listMats;
    public Dropdown dropDownBack;
    
    void Start()
    {
        panelHt = panels[0].transform.localScale.y;
        depth = panels[0].transform.position.z;
        panels[0].transform.position = new Vector3(0, 0, depth);
        panels[1].transform.position = new Vector3(0, panelHt, depth);
        
        background.GetComponent<Renderer>().material = listMats[backgroundChoice];

        //Prevents null reference exception
        if (SceneManager.GetActiveScene().name == "Background")
        {
            dropDownBack.value = backgroundChoice;
            displayBack.GetComponent<Renderer>().material = listMats[dropDownBack.value];
        }
    }
    
    //Sets the background display preview box
    public void SetBackgroundChoice()
    {
        displayBack.GetComponent<Renderer>().material = listMats[dropDownBack.value];
    }

    //Sets the game background
    public void SetBackground()
    {
        backgroundChoice = dropDownBack.value;
        background.GetComponent<Renderer>().material = listMats[backgroundChoice];
    }

    void Update()
    {
        background.GetComponent<Renderer>().material = listMats[backgroundChoice];
        float tY, tX = 0;
        tY = Time.time * scrollSpeed % panelHt + (panelHt * 0.5f);
        if (poi != null)
        {
            tX = -poi.transform.position.x * motionMult;
        }

        panels[0].transform.position = new Vector3(tX, tY, depth);
        if (tY >= 0)
        {
            panels[1].transform.position = new Vector3(tX, tY - panelHt, depth);
        }
        else
        {
            panels[1].transform.position = new Vector3(tX, tY + panelHt, depth);
        }
    }
}

