using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SceneSwitcher ()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        StartGame1Player();
        StartGame2Player();
    }
    void StartGame1Player()
    {
        if (Input.GetButtonDown("Start1"))
        {
            Debug.Log("One player start Game");
            SceneManager.LoadScene(0);
        }
    }

    public void StartGame2Player()
    {
        if (Input.GetButtonDown("Start2"))
        {
            Debug.Log("TWO player start Game");
            SceneManager.LoadScene(0);
        }
    }

}
