using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnBoardPickUp : MonoBehaviour
{
    public AudioSource tickSource;
    public bool isOn;
    public int pickuptype;
    SpriteRenderer m_SpriteRenderer;
    public ScoreBoard myMama;
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
        tickSource = GetComponent<AudioSource>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        TurnOf();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && isOn)
        {
            Debug.Log("GotHere");
            tickSource.Play();
            myMama.BabyGotHit(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, pickuptype);
            TurnOf();
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
}
