using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{

    private Rigidbody2D RB;

    //The Speed that the ball current has, Used to calculate score
    public float CurrentBallSpeed = 0.0f;
    //The value that the balls speed is increased by every tick
    public float SpeedUpValue = 0.00001f;
    //The value that the balls speed is increased by when it hits a player
    public float HitPlayerSpeedUpValue = 0.0f;

    //the speed the balls starts with on the X axis, the Y is also this value but divided by 2
    public float StartSpeed = 1.0f;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        //Randomzies direction to start and adds force on the ball
        RandomizeStartDirection();
    }

    void Update()
    {
        //Limits the speed to velocty 45 so that collisions dont break (NEEDS MORE TESTING)
        if(RB.velocity.x < 45 || RB.velocity.y < 45 || RB.velocity.x > -45 || RB.velocity.y > -45)
        {
            RB.velocity += new Vector2(RB.velocity.x * SpeedUpValue, RB.velocity.y * SpeedUpValue);
        }
        if(RB.velocity.y == 0)
        {
            RB.velocity += new Vector2(0.0f, RB.velocity.y + 0.2f);
        }

        //Sets a float to make score depend on velocity
        CurrentBallSpeed = RB.velocity.x + RB.velocity.y;
    }

    //Sets the start direction and adds force to the ball in that direction
    void RandomizeStartDirection()
    {
        int StartValue = Random.Range(0, 2);

        if(StartValue == 0)
        {
            RB.AddForce(new Vector2(StartSpeed, StartSpeed / 2));
        }
        else if (StartValue == 1)
        {
            RB.AddForce(new Vector2(-StartSpeed, StartSpeed / 2));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp")
        {
            Debug.Log("You tried to pick something up");
        }
        else if (collision.tag == "Player")
        {
            Debug.Log("Entered Player");
            RB.velocity += new Vector2(RB.velocity.x * HitPlayerSpeedUpValue, RB.velocity.y * HitPlayerSpeedUpValue);
        }
        else if (collision.tag == "Goal")
        {
            Debug.Log("Scored");
        }
    }
}
