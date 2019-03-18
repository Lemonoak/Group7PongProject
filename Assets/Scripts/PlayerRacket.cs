using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacket : MonoBehaviour
{
    public string movementkey;
    public float PushForce = 0.0f;
    public bool BallIsInside = false;

    void Start()
    {
        
    }

    void Update()
    {

        if(BallIsInside)
        {
            if(Input.GetButtonDown(movementkey))
            {
                Debug.Log("Tried to push");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            BallIsInside = true;
            Debug.Log("Found Ball");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            BallIsInside = false;
            Debug.Log("Lost Ball");
        }
    }
}
