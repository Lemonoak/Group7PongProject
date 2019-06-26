using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public string GoalName = "Goal";
    //public AudioSource tickSource;
    // Start is called before the first frame update
    void Start()
    {
       // tickSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Scoring is currently handled by the ball so this is redundant
        if (collision.gameObject.tag == "Ball")
           // tickSource.Play();
        {
            //Debug.Log("Score");
           
        }
    }

}



