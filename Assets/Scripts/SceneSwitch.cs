using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(gameObject);
    }
    /*
    public void SceneSwitcher ()
    {
        SceneManager.LoadScene(1);
    }
    void Update()
    {
        Debug.Log(gameObject);
        StartGame1Player();
        StartGame2Player();
    }
    void StartGame1Player()
    {
        if (Input.GetButtonDown("Start1"))
        {
            Debug.Log("One player start Game");
            SceneManager.LoadScene(1);
        }
    }

    public void StartGame2Player()
    {
        if (Input.GetButtonDown("Start2"))
        {
            Debug.Log("TWO player start Game");
            SceneManager.LoadScene(1);
        }
    }
*/
}
