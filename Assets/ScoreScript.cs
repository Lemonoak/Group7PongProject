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
        ScoreSpeed = 0.1f;
        tickSource = GetComponent<AudioSource>();
        textPro = GetComponent<TextMeshProUGUI>();
        textPro.text = playerScore.ToString() + "00";
        // textComp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore >= newScore && gaining)
        {
            playerScore = newScore;
            textPro.text = playerScore.ToString() + "00";            
            tickSource.Stop();
            gaining = false;

            board.DoneScoring();
        }
        else if (playerScore < newScore)
        {
            playerScore += Mathf.FloorToInt(change);
            textPro.text = playerScore.ToString() + "00";
        }

    }
   
    public void NewScoreAdd(float score, float Speed)
    {
        ScoreSpeed = Speed;
        change = Mathf.FloorToInt(score * ScoreSpeed * 1);
        newScore = Mathf.FloorToInt(newScore + (score * 1));
        gaining = true;
        tickSource.Play();
    }
}
