using UnityEngine;
using System.Collections;

//Controls image prefab for player choice
public class PlayerImageControl : PlayerRPS
{

    public Material rockMat, paperMat, sciMat;

    void Start()
    {
        //Image set based on player's choice in Player.cs; changes the material
        if (PlayerRPS.choice == 1)
        {
            this.GetComponent<Renderer>().sharedMaterial = rockMat;
        }
        else if (PlayerRPS.choice == 2)
        {
            this.GetComponent<Renderer>().sharedMaterial = paperMat;
        }
        else
        {
            this.GetComponent<Renderer>().sharedMaterial = sciMat;
        }
    }

}
