using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    float restartTime;
    public float idleTime;
    public GameObject traker;
    // Start is called before the first frame update
    void Start()
    {
        restartTime = Time.fixedTime;
    }
    private void Awake()
    {
        if (GameObject.FindWithTag("GameMode"))
        {
            traker = GameObject.FindWithTag("GameMode");
        }
        else
        {
            traker = Instantiate(traker);
            DontDestroyOnLoad(traker);
        }
        //traker.GetComponent<GameModeController>().RotateAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (idleTime != 0)
        {            
            if (Input.GetAxis("Movement1") != 0 || Input.GetAxis("Movement2") != 0)
            {
                restartTime = Time.fixedTime;
            }
            else if(Time.fixedTime > idleTime + restartTime)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
