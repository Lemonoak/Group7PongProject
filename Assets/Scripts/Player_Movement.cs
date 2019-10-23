using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class Player_Movement : MonoBehaviour
{
    public string movementkey;
    public string exitkey;
    public string PlayerString;
    public float speed = 10f;
    public GameObject TextHandler;

    SpriteRenderer sR;

    public Sprite hitAni;
    public Sprite missAni;
    public Sprite bosstAni;

    Sprite defSpr;
    float animationDelay = 0.3f;
    float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 0)
        {
            if (GameObject.FindWithTag("GameMode").GetComponent<PlayerManager>().screenlayingDown)
            {
                movementkey = "Movement1";
            }
            else
            {
                movementkey = "GMovement1";
            }
            PlayerString = "Player1";
        }
        else
        {
            if (GameObject.FindWithTag("GameMode").GetComponent<PlayerManager>().screenlayingDown)
            {
                movementkey = "Movement2";
            }
            else
            {
                movementkey = "GMovement2";
            }
            PlayerString = "Player2";
        }

        sR = GetComponent<SpriteRenderer>();
        defSpr = sR.sprite;
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f * Input.GetAxis(movementkey));

        if (Input.GetAxis(movementkey) == 1 && this.transform.position.y < 2.1f)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis(movementkey) == -1 && this.transform.position.y > -2f)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        /*Debug.Log(Input.GetAxis(movementkey));
        if (SceneManager.GetActiveScene().name != "lilly_3")
        {
            Destroy(gameObject);
        }*/
        if(Time.fixedTime > lastTime + animationDelay && sR.sprite != defSpr)
        {
            sR.sprite = defSpr;
            GamePad.SetVibration(0, 0, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && sR.sprite == defSpr)
        {
            sR.sprite = hitAni;
            lastTime = Time.fixedTime;
        }
    }

    public void swungRaket(bool didHit)
    {
        if (transform.position.x < 0)
        {
            if (didHit)
            {
                sR.sprite = bosstAni;
                GamePad.SetVibration(PlayerIndex.One, 1, 1);
            }
            else
            {
                sR.sprite = missAni;
                GamePad.SetVibration(PlayerIndex.One, 0.3f, 0.3f);
            }
            lastTime = Time.fixedTime;
        }
        else
        {
            if (didHit)
            {
                sR.sprite = bosstAni;
                GamePad.SetVibration(PlayerIndex.Two, 1, 1);
            }
            else
            {
                sR.sprite = missAni;
                GamePad.SetVibration(PlayerIndex.Two, 0.3f, 0.3f);
            }
            lastTime = Time.fixedTime;
        }
    }
    public bool hasMiss()
    {
        return sR.sprite != missAni;
    }

}

        
            
        
    

