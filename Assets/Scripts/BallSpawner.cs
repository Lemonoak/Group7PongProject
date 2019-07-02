using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballSpawnPoint1;
    public GameObject ballSpawnPoint2;
    public GameObject spawnrefObject;
    GameObject spawnedObject;
    public ScoreBoard scoreBoard;
    public GameObject[] AIReference;
    public GameObject musk;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnBall()
    {
        // musk.GetComponent<AudioSource>().UnPause();
        musk.GetComponent<AudioSource>().volume = 1f;
        Vector2 tempVector;
        if (scoreBoard.PlayerScoar == 1)
        {
            tempVector = ballSpawnPoint2.transform.position;
        }
        else
        {
            tempVector = ballSpawnPoint1.transform.position;
        }
        spawnedObject = (GameObject)Instantiate(spawnrefObject, tempVector, Quaternion.identity);
        spawnedObject.GetComponent<BallMovement>().board = scoreBoard;

        ///////////////////
 
        AIReference = GameObject.FindGameObjectsWithTag("AI");
        //ERROR HANDLING
        if (AIReference.Length == 1)
        {
            AIReference[0].GetComponent<AI>().GetBall();
        }
        if (AIReference.Length > 1)
        {
            AIReference[0].GetComponent<AI>().GetBall();
            AIReference[1].GetComponent<AI>().GetBall();
        }
    }
}
