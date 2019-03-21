using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public string movementkey;
    public string exitkey;
    public string PlayerString;
    public float speed=10f;
    public GameObject TextHandler;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 0)
        {
            movementkey = "Movement1";
            exitkey = "Return1";
            PlayerString = "Player1";
        }
        else
        {
            movementkey = "Movement2";
            exitkey = "Return2";
            PlayerString = "Player2";
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f * Input.GetAxis(movementkey));

        if (Input.GetAxis(movementkey) == 1 && this.transform.position.y < 3f)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis(movementkey) == -1 && this.transform.position.y > -3f)
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
        if (SceneManager.GetActiveScene().name != "lilly_3")
        {
            Destroy(gameObject);
        }   

    }
}

        
            
        
    

