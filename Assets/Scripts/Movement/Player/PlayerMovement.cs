using UnityEngine;
using System.Collections;

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
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement_vector != Vector2.zero)
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
