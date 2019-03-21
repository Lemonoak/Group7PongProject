using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    int playerScore;
    int newScore;
    //TextMeshPro textComp;
    TextMeshProUGUI textPro;
    // Start is called before the first frame update
    void Start()
    {
        textPro= GetComponent<TextMeshProUGUI>();
       // textComp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        textPro.text = newScore.ToString() + "00";
       // textComp.text = "Steve";
=======
        if (playerScore >= newScore && gaining)
        {
            newScore = playerScore;
            textPro.text = playerScore.ToString() + "00";
            Debug.Log("IN SCoreScriPT");
            board.DoneScoring();
            tickSource.Stop();
            gaining = false;

        }
        else if (playerScore < newScore)
        {
            playerScore += Mathf.FloorToInt(change);
            textPro.text = playerScore.ToString() + "00";
        }
>>>>>>> parent of 3e7b027... woho

    }
   
    void NewScoreAdd(float score)
    {
        newScore = Mathf.FloorToInt(score);
    }
}
