using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject Player;
    private GameObject Ball;
    public float AISpeed = 10.0f;
    public string movementkey;
    public string specialKey;
    bool hasNewPlayer;
    //string curentScence = "";
    SpriteRenderer sR;
    public Sprite hitAni;
    Sprite defSpr;

    public Sprite missAni;
    public Sprite bosstAni;

    float animationDelay = 0.3f;
    float lastTime;

    private void Start()
    {/*
        if (transform.position.x < 0)
        {
            specialKey = "Start1";
            movementkey = "Movement1";
        }
        else
        {
            specialKey = "Start2";
            movementkey = "Movement2";
        }*/
        sR = GetComponent<SpriteRenderer>();
        defSpr = sR.sprite;
    }
    void Update()
    {
        HandleMovement();
        //SpawnPlayer();
        //MenuSelfReset();
        if (Time.fixedTime > lastTime + animationDelay && sR.sprite != defSpr)
        {
            sR.sprite = defSpr;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && sR.sprite != bosstAni && sR.sprite != missAni)
        {
            sR.sprite = hitAni;
            lastTime = Time.fixedTime;
        }
    }
    /*
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    */
    void HandleMovement()
    {
        //For the ai on the right monitor
        if(transform.position.x > 0)
        {
            //Checks if there is a ball and then if the balls position is on the ai's screen
            if(Ball && Ball.transform.position.x > 0)
            {
                //Moves the ai upwards
                if(Ball.transform.position.y > gameObject.transform.position.y)
                {
                    transform.Translate(new Vector3(Time.deltaTime * AISpeed, 0.0f, 0.0f));
                }
                //Moves the ai downwards
                else if (Ball.transform.position.y < gameObject.transform.position.y)
                {
                    transform.Translate(new Vector3(-Time.deltaTime * AISpeed, 0.0f, 0.0f));
                }
            }
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.2f, 2.1f), transform.position.z);
        }
        //For the ai on the left monitor
        else if(transform.position.x < 0)
        {
            //Checks if there is a ball and then if the balls position is on the ai's screen
            if (Ball && Ball.transform.position.x < 0)
            {
                //Moves the ai upwards
                if (Ball.transform.position.y < gameObject.transform.position.y)
                {
                    transform.Translate(new Vector3(Time.deltaTime * AISpeed, 0.0f, 0.0f));
                }
                //Moves the ai downwards
                else if (Ball.transform.position.y > gameObject.transform.position.y)
                {
                    transform.Translate(new Vector3(-Time.deltaTime * AISpeed, 0.0f, 0.0f));
                }
            }
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.2f, 2.2f), transform.position.z);
        }
    }

    //Spawns the player if it presses a movementkey
    /*
    void SpawnPlayer()
    {
        //ERROR HANDLING AND MENU
        if(Player)
        {
            if (Input.GetButtonDown(specialKey))
            {
                SceneManager.LoadScene(1);
                Instantiate(Player, new Vector2(transform.position.x, 0), transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    
    void MenuSelfReset()
    {
        if (SceneManager.GetActiveScene().name != curentScence && curentScence == "lilly_3")
        {
            Destroy(gameObject);
        }
        else
        {
            curentScence = SceneManager.GetActiveScene().name;
        }
    }*/

    //Gets the ball object reference
    public void GetBall()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }
    public void swungRaket(bool didHit)
    {
        if (didHit)
        {
            sR.sprite = bosstAni;
        }
        else
        {
            sR.sprite = missAni;
        }
        lastTime = Time.fixedTime;
    }
}
