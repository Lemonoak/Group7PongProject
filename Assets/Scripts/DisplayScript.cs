using UnityEngine;
using System.Collections;

public class DisplayScript : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        //Screen.fullScreen = true;
        if (FindObjectOfType<PlayerManager>().screenlayingDown)
        {
            if (Display.displays.Length > 1)
            Display.displays[1].Activate();
            if (Display.displays.Length > 2)
            Display.displays[2].Activate();
        }
        else
        {
            camera3.targetDisplay = 0;
            Display.displays[0].Activate();
        }
        //Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        /**/
        /*
        
        Debug.Log(gameObject);
            */
    }
    // Update is called once per frame
    void Update()
    {

    }
}