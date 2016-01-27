using UnityEngine;
using System.Collections;

public class RedDragonMovement : MonoBehaviour {

	// Use this for initialization
    Rigidbody2D dragon_rbody;
    Animator dragon_animation;

    public float moveSpeed;
    public float timeBetweenMove = 2.0f;
    public float timeToMove;

    private Vector3 moveDirection;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;

    private float dest_x;
    private float dest_y;


	void Start () {
        dragon_rbody = GetComponent<Rigidbody2D>();
        dragon_animation = GetComponent<Animator>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;

        dragon_animation.SetBool("isWalking", true);
	}

	// Update is called once per frame
	void Update () {
        //Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (dragon_animation.GetBool("isWalking"))
        {
            timeToMoveCounter -= Time.deltaTime;
            dragon_rbody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                dragon_animation.SetBool("isWalking", false);
                timeBetweenMoveCounter = timeBetweenMove;
            }
        }

        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            dragon_rbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                dragon_animation.SetBool("isWalking", true);
                timeToMoveCounter = timeToMove;

                dest_x = Random.Range(-1f, 1f);
                dest_y = Random.Range(-1f, 1f);

                dragon_animation.SetFloat("dest_x", dest_x);
                dragon_animation.SetFloat("dest_y", dest_y);

                moveDirection = new Vector3(dest_x * moveSpeed, dest_y * moveSpeed, 0f);
            }
        }
    }
}

/*

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

*/