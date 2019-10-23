using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacket : MonoBehaviour
{
    public string movementkey;
    public float PushForce = 0.0f;
    public bool BallIsInside = false;
    private GameObject Ball;
    public AudioSource tickSource;
    public ParticleSystem HitParticles;
    public ParticleSystem HitParticlesFailed;
    public bool PlayParticles = true;
    public Player_Movement myMama;

    void Start()
    {
        tickSource = GetComponent<AudioSource>();
        
        if (transform.position.x < 0)
        {
            movementkey = "Push1";
            //gamepad
        }
        else
        {
            movementkey = "Push2";
        }
    }

    void Update()
    {
        if (Input.GetButtonDown(movementkey) && myMama.hasMiss())
        {
            if(BallIsInside)
            {
                tickSource.Play();
                if(PlayParticles)
                {
                    HitParticles.Play();
                }
                myMama.swungRaket(true);
                Ball.GetComponent<BallMovement>().AddSpeed();
                
            }
            else if(!BallIsInside)
            {            
                myMama.swungRaket(false);
                
                if (PlayParticles)
                {
                    if(HitParticlesFailed.isStopped)
                    {
                        HitParticlesFailed.Play();
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {            
            BallIsInside = true;
            Ball = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            BallIsInside = false;
        }
    }
}
