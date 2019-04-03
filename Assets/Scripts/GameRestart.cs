using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    float restartTime;
    public float idleTime;
    // Start is called before the first frame update
    void Start()
    {
        restartTime = Time.fixedTime;
        idleTime = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Movement1") != 0 || Input.GetAxis("Movement2") != 0)
        {
            restartTime = Time.fixedTime;
            Debug.Log("Did a Input");
        }
        else if(Time.fixedTime > idleTime + restartTime)
        {
            SceneManager.LoadScene(0);
        }
    }
}
