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
    void SpawnPickUp()
    {
        allObjects.Add(Instantiate(refobject,
            new Vector2(
                Random.Range(-(cameraRef.transform.position.x), (cameraRef.transform.position.x)),
                Random.Range(-(cameraRef.transform.position.x /2), (cameraRef.transform.position.x / 2))),
                Quaternion.identity));
    }
    public void Reset()
    {
        for(int i = 0; i < allObjects.Count; i++)
        {
            if (allObjects[i] != null)
            {
                Destroy(allObjects[i]);
            }           
        }
        CleanList();
    }
    void CleanList()
    {
        if (allObjects.Count != 0)
        {       
            for( int i = allObjects.Count; i > -1; i--)
            {
                if (allObjects[i] == null)
                {
                    allObjects.RemoveAt(i);
                }
            }
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
}
