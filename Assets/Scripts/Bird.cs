using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f; //Upward force of the "flap".

    private bool isDead = false; //Has the player collided with a wall?
    private Rigidbody2D rb2d; //Holds a reference to the Rigidbody2D component of the bird.
    private Animator anim; //Reference to the Animator component.

    // Start is called before the first frame update
    void Start()
    {
    	//Get reference to the Animator component attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    	//Don't allow control if the bird has died.
        if(isDead == false)
        {
        	//Look for input to trigger a "flap".
            if(Input.GetMouseButtonDown (0))
            {
                rb2d.velocity = Vector2.zero;
                //giving the bird some upward force.
                rb2d.AddForce(new Vector2(0, upForce));
                //tell the animator about it
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D()
    {

        rb2d.velocity = Vector2.zero;
        //If the bird collides with something set it to dead
        isDead = true;
        //Set right animation
        anim.SetTrigger("Die");
        // Call the right function for this action
        GameControl.instance.BirdDied();
    }
}
