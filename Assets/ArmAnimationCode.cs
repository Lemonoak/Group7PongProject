using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimationCode : MonoBehaviour
{
    private Animator aM;
    public ScoreBoard board;
    public BallSpawner theSpawner;
    bool going = false;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        aM = GetComponent<Animator>();
        aM.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(aM.enabled)
        {
            if (aM.GetCurrentAnimatorStateInfo(0).normalizedTime > (startTime + (aM.GetCurrentAnimatorStateInfo(0).length * 0.4f)))
            {
                aM.enabled = false;
            }    
            else if (aM.GetCurrentAnimatorStateInfo(0).normalizedTime > (startTime + 0.5) && going)
            {
                theSpawner.SpawnBall();
                going = false;
            }
            
        }
    }
    public void MoveArmAnimation()
    {
        aM.enabled = true;
        going = true;
        startTime = aM.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
