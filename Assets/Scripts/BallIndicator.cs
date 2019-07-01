﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIndicator : MonoBehaviour
{

    public GameObject Ball;
    public Vector3 baseScale;
    SpriteRenderer rE;
    public SpriteRenderer ballrE;
    void Update()
    {

        GetBall();

        //ERROR HANDLING
        if(Ball)
        {           
            if (Ball.transform.position.x > 0)
            {
                gameObject.transform.position = new Vector2( -1.5f, Ball.transform.position.y);
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -90f));
            }
            else if(Ball.transform.position.x < 0)
            {
                gameObject.transform.position = new Vector2(1.5f, Ball.transform.position.y);
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90f));
            }
            rE.color = Color.white;
        }
        else
        {
            rE.color = Color.clear;
            ballrE.color = Color.clear;
        }
    }
    private void Awake()
    {
        rE = GetComponent<SpriteRenderer>();
        baseScale = ballrE.gameObject.transform.localScale;
    }
    void GetBall()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }
}
