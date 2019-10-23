using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJoinTextHandler : MonoBehaviour
{

    public GameObject Player1Text;
    public GameObject Player2Text;

    public GameObject Screen3Player1Text;
    public GameObject Screen3Player2Text;
    public GameObject Screen3Logo;
    //public bool Player1 = false;
    //public bool Player2 = false;

    private void Start()
    {
        //GetPlayer();
        //Debug.Log(GameObject.FindGameObjectsWithTag("Player").Length);
    }

    public void GetPlayers(bool pl1, bool pl2,bool screenModeDown)
    {
            Player1Text.SetActive(!pl1 && screenModeDown);
            Screen3Player1Text.SetActive(!pl1 && !screenModeDown);
            Player2Text.SetActive(!pl2 && screenModeDown);
            Screen3Player2Text.SetActive(!pl2 && !screenModeDown);
            Screen3Logo.SetActive(!(pl1 || pl2) && !screenModeDown);
        /*
        //PLAYER 1 TEXT  
        if (Player1Text)
            {
                Player1Text.gameObject.SetActive(!pl1);
            }

            if (!Player1Text.activeInHierarchy)
            {
                Player1Text.gameObject.SetActive(!pl1);
            }

        //PLAYER 2 TEXT
            if (Player2Text)
            {
                Player2Text.gameObject.SetActive(!pl2);
            }

            if (!Player2Text.activeInHierarchy)
            {
                Player2Text.gameObject.SetActive(!pl2);
            }
            */
    }

    private void Update()
    {       
        //PLAYER 1 TEXT       
    }
    /*
    public void HandlePlayer1Text()
    {
        Player1 = !Player1;
    }

    public void HandlePlayer2Text()
    {
        Player2 = !Player2;
    }
    
    public void GetPlayer()
    {
        PlayerObj = GameObject.FindGameObjectsWithTag("Player");
        if(PlayerObj.Length > 0)
        {
            if(PlayerObj[0])
            {
                if(PlayerObj[0].GetComponent<Player_Movement>().PlayerString == "Player1")
                {
                    HandlePlayer1Text();
                }
                else if (PlayerObj[0].GetComponent<Player_Movement>().PlayerString == "Player2")
                {
                    HandlePlayer2Text();
                }
            }
            if (PlayerObj.Length > 1)
            {
                if (PlayerObj[1].GetComponent<Player_Movement>().PlayerString == "Player1")
                {
                    HandlePlayer1Text();
                }
                else if (PlayerObj[1].GetComponent<Player_Movement>().PlayerString == "Player2")
                {
                    HandlePlayer2Text();
                }
            }
        }
    }
    */
}
