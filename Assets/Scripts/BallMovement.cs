using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{

    private Rigidbody2D RB;

    public float CurrentBallSpeed = 0.0f;
    public float SpeedUpValue = 0.00001f;

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
        if(RB.velocity.x < 45 && RB.velocity.y < 45)
        {
            RB.velocity += new Vector2(RB.velocity.x * SpeedUpValue, RB.velocity.y * SpeedUpValue);
        }

        //Sets a float to make score depend on velocity
        CurrentBallSpeed = RB.velocity.x + RB.velocity.y;
    }

    void RandomizeStartDirection()
    {
        int StartValue = Random.Range(0, 2);

        if(StartValue == 0)
        {
            RB.AddForce(new Vector2(StartSpeed, 0));
        }
        else if (StartValue == 1)
        {
            RB.AddForce(new Vector2(-StartSpeed, 0));
        }
    }
}
