using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIndicator : MonoBehaviour
{

    public GameObject Ball;
    Vector3 baseScale;
    SpriteRenderer rE;
    public SpriteRenderer ballrE;
    void Update()
    {

        GetBall();

        //ERROR HANDLING
        if(Ball)
        {
            ballrE.gameObject.transform.localScale = baseScale * Mathf.Clamp( 1f - Mathf.Abs(Ball.transform.position.x / 20), 0.5f, 1);
            if (Ball.transform.position.x > 0)
            {
                gameObject.transform.position = new Vector2( -1.24f, Ball.transform.position.y);
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -90f));
            }
            else if(Ball.transform.position.x < 0)
            {
                gameObject.transform.position = new Vector2(1.24f, Ball.transform.position.y);
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90f));
            }
            rE.color = Color.white;
            ballrE.color = Color.white;
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
