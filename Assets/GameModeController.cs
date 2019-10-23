using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameModeController : MonoBehaviour
{
    GameObject[] gamemodeRotation;
    GameObject[] gamemodeText;
    GameObject[] UpUI;
    // Start is called before the first frame update
    void Start()
    {
        //RotateAll();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void RotateAll(bool rotate)
    {
        gamemodeRotation = GameObject.FindGameObjectsWithTag("UI");
        if (rotate)
        {           
            foreach (GameObject item in gamemodeRotation)
            {
                if (item.transform.position.x < 0)
                {
                    item.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    item.transform.eulerAngles = new Vector3(0, 0, 180);
                }
            }

        }
        else
        {
            foreach (GameObject item in gamemodeRotation)
            {
                item.transform.eulerAngles = new Vector3(0, 0, 90);
            }

            /*
            for (int i = 0; i < gamemodeRotation.Length; i++)
            {
                if (screenLayingDown)
                {
                    if (gamemodeRotation[i].transform.position.x < 0)
                    {
                        gamemodeRotation[i].transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        gamemodeRotation[i].transform.eulerAngles = new Vector3(0, 0, 180);
                    }
                }
                else
                {
                    gamemodeRotation[i].transform.eulerAngles = new Vector3(0, 0, 90);
                }
            }
            for (int i = 0; i < gamemodeText.Length; i++)
            {
                if (screenLayingDown)
                {
                    gamemodeText[i].GetComponent<TextMeshProUGUI>().text = "LB: Left       Right :RB";
                    gamemodeText[i].GetComponent<TextMeshProUGUI>().fontSize = 36;
                }
                else
                {
                    gamemodeText[i].GetComponent<TextMeshProUGUI>().text = "Left Stick Up: UP   Left Stick Down: Down";
                    gamemodeText[i].GetComponent<TextMeshProUGUI>().fontSize = 29.3f;
                }
            }*/
        }

    }
}
