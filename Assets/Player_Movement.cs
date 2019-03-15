using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public string movementkey;
    public float speed=10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f * Input.GetAxis(movementkey));
        if (Input.GetAxis(movementkey) != 0)
        {
            //Debug.Log(movementkey);
        }

        /*var dave = this.transform.position;

        dave.x = Mathf.Clamp(dave.x, -10f, 10f);
        this.transform.position = dave;
        *//*
      this.transform.position.y > -10f)
                {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -10f);

        
                else this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -0f);

         this.transform.position.y < 10f && this.transform.position.y > -10f);
        { 
                {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f * Input.GetAxis(movementkey));
        
                else
                {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }


            if (Input.GetAxis(movementkey) != 0 && this.transform.position.y < 10f && this.transform.position.y > -10f)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f* Input.GetAxis(movementkey));
                }
                else
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                }
  
                if (Input.GetAxis(movementkey) == 1 && this.transform.position.y < 10f)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);



                }

                else if (Input.GetAxis(movementkey) == -1 && this.transform.position.y > -10f)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);

                }
                else this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -0f);
                */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}

        
            
        
    

