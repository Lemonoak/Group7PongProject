using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillField : MonoBehaviour
{

    public ArmAnimationCode MonkeyArmP1;
    public ArmAnimationCode MonkeyArmP2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            int StartNumber = Random.Range(0, 2);
            if(StartNumber == 1)
            {
                Debug.Log("Ball hit killzone");
                MonkeyArmP1.MoveArmAnimation();
            }
            else
            {
                Debug.Log("Ball hit killzone");
                MonkeyArmP2.MoveArmAnimation();
            }
        }
    }

}
