using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    int playerScore = 0;
    int newScore = 0;
    float change = 0;
    bool gaining = false;
    public float ScoreSpeed = 0.1f;
    //TextMeshPro textComp;
    TextMeshProUGUI textPro;
    public ScoreBoard board;
    public AudioSource tickSource;
    // Start is called before the first frame update
    void Start()
    {
        tickSource = GetComponent<AudioSource>();
        textPro = GetComponent<TextMeshProUGUI>();
        textPro.text = playerScore.ToString() + "00";
        // textComp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        textPro.text = newScore.ToString() + "00";
       // textComp.text = "Steve";
=======
=======
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of 3841ac9... test
        if (playerScore >= newScore && gaining)
        {
            newScore = playerScore;
            textPro.text = playerScore.ToString() + "00";
<<<<<<< HEAD
<<<<<<< HEAD
            Debug.Log("IN SCoreScriPT");
=======
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of 3841ac9... test
            board.DoneScoring();
            tickSource.Stop();
            gaining = false;

        }
        else if (playerScore < newScore)
        {
            playerScore += Mathf.FloorToInt(change);
            textPro.text = playerScore.ToString() + "00";
        }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 3e7b027... woho
=======
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of 3841ac9... test

    }
   
    public void NewScoreAdd(float score)
    {
        change = Mathf.FloorToInt(score * ScoreSpeed);
        newScore = Mathf.FloorToInt(score + playerScore);
        gaining = true;
        tickSource.Play();
    }
}
