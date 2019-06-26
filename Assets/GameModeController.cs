using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameModeController : MonoBehaviour
{
    public bool screenLayingDown = true;
    GameObject[] gamemodeRotation;
    GameObject[] gamemodeText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindWithTag("Player"))
        {
            if (Input.GetButtonDown("Return1") || Input.GetButtonDown("Return2"))
            {
                screenLayingDown = !screenLayingDown;
                RotateAll();
            }
        }
    }
    public void RotateAll()
    {
        gamemodeRotation = GameObject.FindGameObjectsWithTag("UI");
        gamemodeText = GameObject.FindGameObjectsWithTag("ControllText");
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
        }
    }
}
