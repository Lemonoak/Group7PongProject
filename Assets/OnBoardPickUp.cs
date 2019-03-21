using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoardPickUp : MonoBehaviour
{
    public bool isOn;
    public int pickuptype;
    SpriteRenderer m_SpriteRenderer;
    public ScoreBoard myMama;
    // Start is called before the first frame update
    void Start()
    {
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
            TurnOf();
        }
        if(isOn)
        {
            myMama.BabyGotHit(collision.gameObject, pickuptype);
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
