using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    public Rigidbody2D RB;

    public float Speed = 1f;

    public bool IsMovingRight = false;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(RB.transform.position.x > 15)
        {
            IsMovingRight = false;
        }
        if (RB.transform.position.x < -15)
        {
            IsMovingRight = true;
        }

        if(IsMovingRight)
        {
            transform.Translate(new Vector3(1.0f * Speed, 0.0f, 0.0f));
        }
        if (!IsMovingRight)
        {
            transform.Translate(new Vector3(-1.0f * Speed, 0.0f, 0.0f));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PickUp")
        {
            Debug.Log("You tried to pick something up");
        }
    }
}
