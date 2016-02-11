using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
    Rigidbody2D rbody;
    Animator animation;

	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 movement_vector;

        if(Input.GetKey(KeyCode.Space))
            movement_vector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position);
        else
            movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        //// better way?  doesnt work
        //if (movement_vector.x > 1)
        //    movement_vector.x = 1;
        //else if (movement_vector.x < 1)
        //    movement_vector.x = -1;
        //else
        //    movement_vector.x = 0;

        //if (movement_vector.y > 1)
        //    movement_vector.y = 1;
        //else if (movement_vector.y < 1)
        //    movement_vector.y = -1;
        //else
        //    movement_vector.y = 0;




        if ((movement_vector != Vector2.zero))
        {
                animation.SetBool("isWalking", true);
                animation.SetFloat("input_x", movement_vector.x);
                animation.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            animation.SetBool("isWalking", false);
        }
        
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
    }
}