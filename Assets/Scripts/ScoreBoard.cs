using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text scoreboardPlayer1;
    public TMP_Text scoreboardPlayer2;
    public List<Collectables> player1Icons;
    public List<Collectables> player2Icons;
<<<<<<< HEAD

    public PickUpSpawner pickupManager;

    public GameObject music;

    public int PlayerScoar = 1;
=======
    private int PlayerScoar = 1;
>>>>>>> parent of 88c25d1... unchecked warnings
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BabyGotHit(GameObject ball, int pickuptype)
    {
        if (ball.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            player1Icons[pickuptype].TurnOn();
            if (HasColected(player1Icons))
            {

            }
        }
        else
        {
            player2Icons[pickuptype].TurnOn();
            if (HasColected(player2Icons))
            {

            }
        }
    }
    public void TurnOfAll()
    {
        for (int i = 0; i < player1Icons.Count; i++)
        {
            player1Icons[i].TurnOf();
            player2Icons[i].TurnOf();
        }
    }
    bool HasColected (List<Collectables> icons)
    {
        for (int i = 0; i < icons.Count; i++)
        {
            if (!icons[i].isOn)
            {
                return false;
            }
        }
        return true;
    }
    void TurnOfScoreSide(List<Collectables> icons)
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].TurnOf();

        }
    }
    public void scored (int playerGoal, float score) // score is standin
    {
        music.GetComponent<AudioSource>().Pause();
        PlayerScoar = playerGoal;
        if (playerGoal  == 1)
        {

        }
        else
        {

        }
    }
}
