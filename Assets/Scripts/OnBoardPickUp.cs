using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnBoardPickUp : MonoBehaviour
{
    public AudioSource tickSource;
    public bool isOn = false;
    public int pickuptype;
    SpriteRenderer m_SpriteRenderer;
    public ScoreBoard myMama;
    public GameObject ScoreText;
    public float TextTimer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {/*
        tickSource = GetComponent<AudioSource>();

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        TurnOf();
        */
    }
    private void Awake()
    {
        TextTimer = 0;
        tickSource = GetComponent<AudioSource>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        TurnOf();
    }
    // Update is called once per frame
    void Update()
    {
        TextTimer -= Time.deltaTime;
        if(TextTimer < 0)
        {
            TurnOffText();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && isOn)
        {
            tickSource.Play();
            myMama.BabyGotHit(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, pickuptype);
            TurnOf();
            TurnOnText(collision.GetComponent<Rigidbody2D>().velocity.x);
        }       
    }
    public void TurnOn()
    {
        m_SpriteRenderer.color = Color.white;
        isOn = true;
    }
    public void TurnOf()
    {
        m_SpriteRenderer.color = Color.grey;
        isOn = false;
    }
    public void TurnOnText(float diraction)
    {
        if (GameObject.FindWithTag("GameMode").GetComponent<PlayerManager>().screenlayingDown)
        {
            if(diraction < 0)
            {
                ScoreText.transform.eulerAngles = new Vector3(0,0, 90);
            }
            else
            {
                ScoreText.transform.eulerAngles = new Vector3(0,0, -90);
            }
        }
        else
        {
            ScoreText.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(ScoreText)
        {
            ScoreText.SetActive(true);
            TextTimer = 0.7f;
        }
    }
    public void TurnOffText()
    {
        if (ScoreText)
        {
            ScoreText.SetActive(false);
        }
    }
}
