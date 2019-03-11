using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject refobject;
    public List<GameObject> allObjects;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPickUp();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnPickUp()
    {
        //Instantiate(refobject, new Vector2(0,0), Quaternion.identity);
        allObjects.Add(Instantiate(refobject, new Vector2(0, 0), Quaternion.identity));
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
        for( int i = allObjects.Count; i > -1; i--)
        {
            if (allObjects[i] == null)
            {
                allObjects.RemoveAt(i);
            }
        }
    }
}
