using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    public ScoreBoard board;
    private Rigidbody2D RB;
    public GameObject spawner;
    //for the AI to see the ball
    public GameObject Ball;

    //The Speed that the ball current has, Used to calculate score
    public float CurrentBallSpeed = 0.0f;
    //The value that the balls speed is increased by every tick
    public float SpeedUpValue = 0.00001f;
    //The value that the balls speed is increased by when it hits a player
    public float HitPlayerSpeedUpValue = 0.0f;

    //the speed the balls starts with on the X axis, the Y is also this value but divided by 2
    public float StartSpeed = 1.0f;
    public AudioSource tickSource;


    float CurrentX = 0.0f;
    float CurrentY = 0.0f;

    bool PlayerSmashed = false;

    float OldVeloctyX;
    float OldVeloctyY;
    Vector2 oldVelocty;
    float maxVelocityPart = 1;
    float funXSpeed = 8;
    float funYSpeed = 0.2f;

    void Start()
    {

        tickSource = GetComponent<AudioSource>();

        RB = GetComponent<Rigidbody2D>();
        Ball = gameObject;
        //Randomzies direction to start and adds force on the ball
        RandomizeStartDirection();
    }

    void Update()
    {
        //Limits the speed to velocty 45 so that collisions dont break (NEEDS MORE TESTING)
        if (RB.velocity.x < 45 || RB.velocity.y < 45 || RB.velocity.x > -45 || RB.velocity.y > -45)
        {
            RB.velocity += new Vector2(RB.velocity.x * SpeedUpValue, RB.velocity.y * SpeedUpValue);
        }
        //Makes the ball add velocity upwards if it happens to only go on the x axis
        if (RB.velocity.y == 0)
        {
            RB.velocity += new Vector2(0.0f, RB.velocity.y + 0.2f);
        }

        CurrentX = Mathf.Round(RB.velocity.x);
        CurrentY = Mathf.Round(RB.velocity.y);

        //Sets a float to make score depend on velocity
        //CurrentBallSpeed = CurrentX + CurrentY;

        if (CurrentX < 0 && CurrentY < 0)
        {
            CurrentBallSpeed = Mathf.Abs(CurrentY) + Mathf.Abs(CurrentX);
            //Debug.Log("  Ball Speed  X , Y = " + Mathf.Round(CurrentBallSpeed));
            //Debug.Log("  Y   " + CurrentY);
            //Debug.Log("  X   " + CurrentX);
        }
        else if (CurrentX < 0)
        {

            CurrentBallSpeed = Mathf.Abs(CurrentX) + CurrentY;
            //Debug.Log("  Ball Speed   X = " + Mathf.Round(CurrentBallSpeed));
            //Debug.Log("  X   " + CurrentX);
            //Debug.Log("  Y   " + CurrentY);
        }
        else if (CurrentY < 0)
        {

            CurrentBallSpeed = Mathf.Abs(CurrentY) + CurrentX;
            //Debug.Log("  Ball Speed  Y = " + Mathf.Round(CurrentBallSpeed));
            //Debug.Log("  Y   " + CurrentY);
            //Debug.Log("  X   " + CurrentX);
        }

        if(Ball.transform.position.x < - 5000)
        {
            Destroy(gameObject);
        }
        else if (Ball.transform.position.x > 5000)
        {
            Destroy(gameObject);
        }
        
        if(RB.velocity.x != 0)
        {
            RB.velocity = Maxvelocity(); // the y speed relative to x need to be fixt
        }
        

    }

    Vector2 Maxvelocity()
    {
        Vector2 velocityClamp = new Vector2( Mathf.Abs(RB.velocity.x), Mathf.Abs(RB.velocity.y));
        float remainder;
        if (velocityClamp.x < funXSpeed)
        {       
            for (; velocityClamp.y/ velocityClamp.x > maxVelocityPart;)
            {
                remainder = velocityClamp.y * 0.05f;
                velocityClamp.y -= remainder;
                velocityClamp.x += remainder;
            }
        }
        if (velocityClamp.y < funYSpeed)
        {
            velocityClamp.x -= (funYSpeed - velocityClamp.y);
            velocityClamp.y = funYSpeed;
            /*
            for (; velocityClamp.x / velocityClamp.y > maxVelocityPart;)
            {
                remainder = velocityClamp.x * 0.05f;
                velocityClamp.y += remainder;
                velocityClamp.x -= remainder;
            }
            */
        }
        if (velocityClamp.x + velocityClamp.y < Mathf.Abs(oldVelocty.x) + Mathf.Abs(oldVelocty.y))
        {
            Debug.Log("GotSlower");
            velocityClamp.x = Mathf.Abs(oldVelocty.x);
            velocityClamp.y = Mathf.Abs(oldVelocty.y);
        }
        if (RB.velocity.x < 0)
        {
            velocityClamp.x *= -1;
        }
        if (RB.velocity.y < 0)
        {
            velocityClamp.y *= -1;
        }        
        return velocityClamp;
    }
    //Sets the start direction and adds force to the ball in that direction
    void RandomizeStartDirection()
    {
        int StartValue = Random.Range(0, 2);

        if (transform.position.x > 0)
        {
            RB.AddForce(new Vector2(StartSpeed, StartSpeed / 2));
        }
        else
        {
            RB.AddForce(new Vector2(-StartSpeed, -StartSpeed / 2));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            tickSource.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp" && collision.GetComponent<OnBoardPickUp>().isOn)
        {            
            RB.velocity += new Vector2(RB.velocity.x * SpeedUpValue, RB.velocity.y * SpeedUpValue);
        }
        else if (collision.tag == "Player")
        {
            Debug.Log("Entered Player");
            //ERROR HANDLING
            if(PlayerSmashed)
            {
                RemoveSpeed();
            }
        }
        else if (collision.tag == "AI")
        {
            Debug.Log("Entered AI");
            //ERROR HANDLING
            if (PlayerSmashed)
            {
                RemoveSpeed();
            }
        }
        else if (collision.tag == "Goal")
        {
            //ERROR HANDLING
            if (collision.GetComponent<Goal>() != null)
            {

                if (transform.position.x < 0)
                {
                    board.Scored(2, Mathf.Abs(RB.velocity.x) + Mathf.Abs(RB.velocity.y));
                }
                else
                {
                    board.Scored(1, Mathf.Abs(RB.velocity.x) + Mathf.Abs(RB.velocity.y));
                }
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Goal is missing goal component or has the wrong GoalName");
            }
        }
    }

    public void AddSpeed()
    {
        PlayerSmashed = true;
        OldVeloctyX = RB.velocity.x;
        OldVeloctyY = RB.velocity.y;
        RB.velocity += new Vector2(RB.velocity.x * HitPlayerSpeedUpValue, RB.velocity.y * HitPlayerSpeedUpValue);
    }

    public void RemoveSpeed()
    {
        PlayerSmashed = false;
        RB.velocity = new Vector2(OldVeloctyX, OldVeloctyY);
        oldVelocty = RB.velocity;
    }
}
