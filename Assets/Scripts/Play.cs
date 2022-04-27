using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public int speed;

    private Rigidbody2D myRB;
    private Vector2 vector;
    private Animator myAnim;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }


    void Update()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");

        //myRB.velocity = vector * normalized * speed * Time.deltaTime; 
    }
}
