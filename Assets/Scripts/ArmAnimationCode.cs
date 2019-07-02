using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimationCode : MonoBehaviour
{
    private Animator aM;
    public ScoreBoard board;
    public BallSpawner theSpawner;
    public Animation aN;
    float time;
    bool going = false;
    float startTime;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        
        aM = GetComponent<Animator>();
        aM.Play("", 0, aM.GetCurrentAnimatorStateInfo(0).length);
        
    }
    // Update is called once per frame
    void Update()
    {        
        if (aM.enabled)
        {
             if (Time.fixedTime > (time + (aM.GetCurrentAnimatorStateInfo(0).length * 0.5)) && going)
            {
                theSpawner.SpawnBall();
                going = false;
                
            }
            
        }
    }
    public void MoveArmAnimation()
    {
        
        aM.Play("", 0, 0f);
        going = true;
        
        time = Time.fixedTime;

        
        //startTime = aM.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
