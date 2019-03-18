using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public GameObject Player;
    private GameObject Ball;
    public float AISpeed = 10.0f;

    void Update()
    {
        HandleMovement();
        SpawnPlayer();
    }

    void HandleMovement()
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
    }

    //Spawns the player if it presses a movementkey
    void SpawnPlayer()
    {
        if (Input.GetButtonDown("Movement2"))
        {
            Instantiate(Player, transform.position, Quaternion.Euler(0.0f, 0.0f, 90.0f));
            Destroy(gameObject);
        }
    }

    //Gets the ball object reference
    public void GetBall()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }
}
