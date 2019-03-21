using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimationCode : MonoBehaviour
{
    private Animator aM;
    public ScoreBoard board;
    public BallSpawner theSpawner;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
    public Animation aN;
    float time;
>>>>>>> parent of 3841ac9... test
=======
    public Animation aN;
    float time;
>>>>>>> parent of 3841ac9... test
=======
    public Animation aN;
    float time;
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
=======
    public Animation aN;
    float time;
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
    bool going = false;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        aM = GetComponent<Animator>();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        aM.enabled = false;
=======
        aM.Play("", 0, aM.GetCurrentAnimatorStateInfo(0).length);
>>>>>>> parent of 3841ac9... test
=======
        aM.Play("", 0, aM.GetCurrentAnimatorStateInfo(0).length);
>>>>>>> parent of 3841ac9... test
=======
        aM.Play("", 0, aM.GetCurrentAnimatorStateInfo(0).length);
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
=======
        aM.Play("", 0, aM.GetCurrentAnimatorStateInfo(0).length);
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        if(aM.enabled)
        {
            if (aM.GetCurrentAnimatorStateInfo(0).normalizedTime > (startTime + (aM.GetCurrentAnimatorStateInfo(0).length * 0.4f)))
            {
                aM.enabled = false;
            }    
            else if (aM.GetCurrentAnimatorStateInfo(0).normalizedTime > (startTime + 0.5) && going)
=======
=======
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
=======
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
        
        if (aM.enabled)
        {
             if (Time.fixedTime > (time + (aM.GetCurrentAnimatorStateInfo(0).length * 0.5)) && going)
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
=======
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
            {
                theSpawner.SpawnBall();
                going = false;
            }
            
        }
    }
    public void MoveArmAnimation()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        aM.enabled = true;
        going = true;
        startTime = aM.GetCurrentAnimatorStateInfo(0).normalizedTime;
=======
=======
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
=======
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
        aM.Play("", 0, 0f);
        going = true;
        Debug.Log(aM.GetCurrentAnimatorStateInfo(0).normalizedTime + " is normalizedTime");
        time = Time.fixedTime;

        //startTime = aM.GetCurrentAnimatorStateInfo(0).normalizedTime;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of 3841ac9... test
=======
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
=======
>>>>>>> parent of dd3815f... Merge branch 'master' of https://github.com/Lemonoak/Group7PongProject
    }
}
