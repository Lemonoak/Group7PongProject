using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballSpawnPoint1;
    public GameObject ballSpawnPoint2;
    public GameObject spawnrefObject;
    GameObject spawnedObject;
    public GameObject[] AIReference;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
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

    // Update is called once per frame
    void Update()
    {
        if(spawnedObject == null)
        {
            SpawnBall();
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
    public void SpawnBall()
    {
        Vector2 tempVector;
        if (Random.value > 0.5f)
        {
            tempVector = ballSpawnPoint2.transform.position;
        }
        else
        {
            tempVector = ballSpawnPoint1.transform.position;
        }
        spawnedObject = (GameObject)Instantiate(spawnrefObject, tempVector, Quaternion.identity);
    }
}
