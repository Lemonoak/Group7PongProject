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
    // Start is called before the first frame update
    void Start()
    {
        textPro= GetComponent<TextMeshProUGUI>();
        textPro.text = playerScore.ToString() + "00";
        // textComp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore >= newScore && gaining)
        {
            newScore = playerScore;
            textPro.text = playerScore.ToString() + "00";
            Debug.Log("IN SCoreScriPT");
            board.DoneScoring();
            gaining = false;

        }
        else if (playerScore < newScore)
        {
            playerScore += Mathf.FloorToInt(change);
            textPro.text = playerScore.ToString() + "00";
        }

    }
   
    public void NewScoreAdd(float score)
    {
        change = Mathf.FloorToInt(score * ScoreSpeed);
        newScore = Mathf.FloorToInt(score + playerScore);
        gaining = true;
    }
}
