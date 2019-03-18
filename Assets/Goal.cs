using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    public string GoalName = "Goal";

    private BallMovement Score;

    public Text ScoreText;
    float CurrentScore;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Score = GameObject.FindObjectOfType<BallMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Scoring is currently handled by the ball so this is redundant
        if (collision.gameObject.tag == "Ball")
        {
            CurrentScore += Score.CurrentBallSpeed;
            ScoreText.text = CurrentScore.ToString();
            Debug.Log("Score" + Score.CurrentBallSpeed);
        }
    }

}



