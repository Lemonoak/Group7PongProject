using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public string GoalName = "Goal";

    private BallMovement Balli;


    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Balli = GameObject.FindObjectOfType<BallMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Scoring is currently handled by the ball so this is redundant
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Score" + Balli.CurrentBallSpeed);
        }
    }

}



