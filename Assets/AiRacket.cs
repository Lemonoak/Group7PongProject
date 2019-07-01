using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRacket : MonoBehaviour
{
    public float PushForce = 0.0f;
    public bool BallSwing = false;
    private GameObject Ball;
    public AudioSource tickSource;
    //public ParticleSystem HitParticles;
    public ParticleSystem HitParticlesFailed;
    public bool PlayParticles = true;
    public AI myMama;

    void Start()
    {

    }

    void Update()
    {
        /*
        if (BallIsInside)
        {
            if (Input.GetButtonDown(movementkey))
            {

                tickSource.Play();
                Debug.Log("Tried to push");
                myMama.swungRaket(true);
                Ball.GetComponent<BallMovement>().AddSpeed();
            }
        }
        else if (!BallIsInside)
        {

            if (Input.GetButtonDown(movementkey))
            {
                myMama.swungRaket(false);

                if (PlayParticles)
                {
                    if (HitParticlesFailed.isStopped)
                    {
                        HitParticlesFailed.Play();
                    }
                }

            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            if (Random.Range(0,4) == 0)
            {
                myMama.swungRaket(true);
                collision.GetComponent<BallMovement>().AddSpeed();
                BallSwing = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ball" && !BallSwing && Random.Range(0, 2) == 0)
        {
            myMama.swungRaket(false);
            if (PlayParticles)
            {
                if (HitParticlesFailed.isStopped)
                {
                    HitParticlesFailed.Play();
                }
            }
        }
        BallSwing = false;
    }
}
