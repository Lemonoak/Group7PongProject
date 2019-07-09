using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    int playerScore = 0;
    int newScore = 0;
    float change = 10;
    bool gaining = false;
    float ScoreSpeed = 10f;
    float lastTime= 0;
    string frontBuffer;
    string BackBuffer;
    //TextMeshPro textComp;
    TextMeshProUGUI textPro;
    public ScoreBoard board;
    public AudioSource tickSource;
    // Start is called before the first frame update
    void Start()
    {
        ScoreSpeed = 0.2f;
        tickSource = GetComponent<AudioSource>();
        textPro = GetComponent<TextMeshProUGUI>();
        DrawScore();
        // textComp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore >= newScore && gaining)
        {
            playerScore = newScore;          
            tickSource.Stop();
            gaining = false;
            DrawScore();

            board.DoneScoring();
        }
        else if (playerScore < newScore && lastTime > ScoreSpeed)
        {           
            if (lastTime > ScoreSpeed)
            {
                lastTime = 0;
                playerScore += Mathf.FloorToInt(change);
                DrawScore();
            }               
        }
        lastTime = Mathf.Clamp(lastTime + Time.deltaTime, 0, ScoreSpeed * 2);

    }
   
    public void NewScoreAdd(float score)
    {
        newScore = Mathf.FloorToInt(newScore + score);
        gaining = true;
        tickSource.Play();
    }
    private void DrawScore()
    {
        frontBuffer = "";
        for (long i = 1000000000000; i > playerScore; i = i /10)
        {
            frontBuffer += "0";
        }
        if(playerScore == 0)
        {
            BackBuffer = "0";
        }
        else
        {
            BackBuffer = "00";
        }
        textPro.text = frontBuffer + playerScore.ToString() + BackBuffer;
    }
}
