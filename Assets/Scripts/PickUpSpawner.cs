using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject refobject;
    public GameObject cameraRef;
    public float spawnInterwal;
    public float startDelay;
    float tempDelay;
    float tempInterwal;
    public List<OnBoardPickUp> leftPickups;
    public List<OnBoardPickUp> rightPickups;

    public List<GameObject> allObjects;
    // Start is called before the first frame update
    void Start()
    {
        tempDelay = Time.fixedTime;
        tempInterwal = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > startDelay + tempDelay 
            && Time.fixedTime > spawnInterwal + tempInterwal)
        {
            // CleanList();
            TurnOnPickup();
            tempInterwal = Time.fixedTime;
        }
    }

    void TurnOnPickup()
    {
        if (Random.value > 0.5f)
        {
            leftPickups[Random.Range(0, 3)].TurnOn();
        }
        else
        {
            rightPickups[Random.Range(0, 3)].TurnOn();
        }

    }
    public void TurnOfAll()
    {
        for (int i = 0; i < leftPickups.Count; i++)
        {
            leftPickups[i].TurnOf();
            rightPickups[i].TurnOf();
        }
        tempDelay = Time.fixedTime;
    }
}
