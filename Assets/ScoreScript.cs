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
        textPro.text = newScore.ToString() + "00";
       // textComp.text = "Steve";

    }
   
    void NewScoreAdd(float score)
    {
        newScore = Mathf.FloorToInt(score);
    }
}
