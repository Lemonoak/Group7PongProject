using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(640, 480, false);
    }
    public void StartgameWhithScreens(bool LayingDown)
    {
        FindObjectOfType<PlayerManager>().screenlayingDown = LayingDown;
        SceneManager.LoadScene(1);
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }
}
