using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Vector3 startPosiotion1 = new Vector3(-15.75f,0,0);
    Vector3 startPosiotion2 = new Vector3(15.75f,0,0);

    Quaternion ref_StartRotation1;
    Quaternion ref_StartRotation2;

    bool playerOneIsIn = false;
    bool playerTwoIsIn = false;

    public GameObject playerGameobject;
    public GameObject aIGameobject;

    GameObject playerOne;
    GameObject playerTwo;

    GameModeController gameMode;
    PlayerJoinTextHandler textaManeger;

    float restartTime = 0;
    float idleTime = 60;

    bool original = false;
    public bool screenlayingDown = false;
    private void Awake()
    {
        gameMode = GetComponent<GameModeController>();
        if (FindObjectsOfType<PlayerManager>().Length == 1)
        {
            DontDestroyOnLoad(gameObject);
            if (SceneManager.GetActiveScene().name != "MainMenuScreen")
            {
                CreatePlayers();
            }
            restartTime = Time.fixedTime;                            
            original = true;      
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("QuitGame"))
        {
            if (!GameObject.FindWithTag("Player"))
            {
                Application.Quit();
            }
            else
            {
                playerOneIsIn = false;
                playerTwoIsIn = false;
                SceneManager.LoadScene(1);
            }
        }
        if(GameObject.FindWithTag("Player") && (Input.GetButtonDown("Return1") && playerOneIsIn) || (Input.GetButtonDown("Return2") && playerTwoIsIn))
        {
            playerOneIsIn = false;
            playerTwoIsIn = false;
            SceneManager.LoadScene(1);
        }

        if (idleTime != 0 && (playerOneIsIn || playerTwoIsIn))
            {
                if (Input.GetAxis("Movement1") != 0 || Input.GetAxis("Movement2") != 0)
                {
                    restartTime = Time.fixedTime;
                }
                else if (Time.fixedTime > idleTime + restartTime)
                {
                    playerOneIsIn = false; 
                    playerTwoIsIn = false;
                    SceneManager.LoadScene(1);
                }
            }

        if (Input.GetButtonDown("Start1") && !playerOneIsIn)
        {
            playerOneIsIn = true;
            RestartLevel();
        }
        if (Input.GetButtonDown("Start2") && !playerTwoIsIn)
        {
            playerTwoIsIn = true;
            RestartLevel();
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if (original)
        {        
            RotateField();
            restartTime = Time.fixedTime;
            if (!GameObject.FindWithTag("AI") && !GameObject.FindWithTag("Player"))
            {
                CreatePlayers();
            }
        }
    }
    void CreatePlayers()
    {
        textaManeger = FindObjectOfType<PlayerJoinTextHandler>();
        textaManeger.GetPlayers(playerOneIsIn, playerTwoIsIn,screenlayingDown);
        if (playerOneIsIn)
        {
            playerOne = Instantiate(playerGameobject, startPosiotion1, ref_StartRotation1);
        }
        else
        {
            playerOne = Instantiate(aIGameobject, startPosiotion1, ref_StartRotation1);
        }
        playerOne.transform.eulerAngles = new Vector3(0, 0, -90);
        if (playerTwoIsIn)
        {
            playerTwo = Instantiate(playerGameobject, startPosiotion2, ref_StartRotation2);
        }
        else
        {
            playerTwo = Instantiate(aIGameobject, startPosiotion2, ref_StartRotation2);
        }
        playerTwo.transform.eulerAngles = new Vector3(0, 0, 90);   
    }
    void RotateField()
    {
        gameMode.RotateAll(screenlayingDown);
    }
    void RestartLevel()
    {
        if (playerOne.tag == "Player")
        {
            startPosiotion1 = playerOne.transform.position;
        }
        else
        {
            startPosiotion1 = new Vector3(-15.75f, 0, 0);
        }
        if (playerTwo.tag == "Player")
        {
            startPosiotion2 = playerTwo.transform.position;
        }
        else
        {
            startPosiotion2 = new Vector3(15.75f, 0, 0);
        }
        SceneManager.LoadScene(1);
    }

}
