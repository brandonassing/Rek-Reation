using UnityEngine;
using System.Collections;

public class ButtonMG : MonoBehaviour {

    /// <summary>
    /// Controls image buttons
    /// </summary>

    public ScreenManager SM;

	void OnMouseUpAsButton()
    {
        if (this.gameObject == GameObject.Find("Play"))
        {
            SM.LoadPlay();
        }
        else if(this.gameObject == GameObject.Find("Quit"))
        {
            SM.Quit();
        }
        else if (this.gameObject == GameObject.Find("Replay"))
        {
            SM.LoadPlay();
        }
        else if (this.gameObject == GameObject.Find("Menu"))
        {
            SM.LoadMenu();
        }
    }
}
