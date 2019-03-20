using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public string movementkey;
    public string exitkey;
    public float speed=10f;

    public GameObject aI;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 0)
        {
            movementkey = "Movement1";
            exitkey = "Return1";
        }
        else
        {
            movementkey = "Movement2";
            exitkey = "Return2";
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f * Input.GetAxis(movementkey));

        if (Input.GetAxis(movementkey) == 1 && this.transform.position.y < 4.5f)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);

        }
        else if (Input.GetAxis(movementkey) == -1 && this.transform.position.y > -4.5f)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);

        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        if (Input.GetButtonDown(exitkey))
        {
            SceneManager.LoadScene(1);
        }
        if (SceneManager.GetActiveScene().name != "TestScene3")
        {
            Destroy(gameObject);
        }   

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}

        
            
        
    

