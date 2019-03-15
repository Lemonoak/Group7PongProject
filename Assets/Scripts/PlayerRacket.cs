using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacket : MonoBehaviour
{

    public float PushForce = 0.0f;
    private GameObject Ball;
    public bool BallIsInside = false;
    public float PushTimer = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {

        if(BallIsInside)
        {
            PushTimer -= Time.deltaTime;
            if (PushTimer <= 0.3)
            {
                //Small push
                Debug.Log("Small Push");
            }
            else if (PushTimer <= 0.2f)
            {
                //Medium Push
                Debug.Log("Medium Push");
            }
            else if (PushTimer < 0.1f)
            {
                //Large Push
                Debug.Log("Large Push");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            BallIsInside = true;
            PushTimer = 0.3f;
            Debug.Log("Found Ball");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            BallIsInside = false;
            PushTimer = 0.0f;
            Debug.Log("Lost Ball");
        }
    }
}
