﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
    public Animator animator;

	private Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	public void FixedUpdate() {
        //Check if player is moving 
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        bool isMovingX = Mathf.Abs(xInput) > 0.5;
        bool isMovingY = Mathf.Abs(yInput) > 0.5;

        if (isMovingX || isMovingY)
        {
            Vector2 movement = new Vector2(0, 0);

            if (xInput > 0) // Left up/down movement
            {
                animator.SetFloat("SpeedY", 0);
                animator.SetFloat("SpeedX", xInput);
                if (yInput == 0)
                    movement.Set(1, 0);
                else if (yInput > 0)
                    movement.Set(1, .5f);
                else
                    movement.Set(1, -.5f);
            }

            if (xInput < 0) // Right up/down movement
            {
                animator.SetFloat("SpeedY", 0);
                animator.SetFloat("SpeedX", xInput);
                if (yInput == 0)
                    movement.Set(-1, 0);
                else if (yInput > 0)
                    movement.Set(-1, .5f);
                else
                    movement.Set(-1, -.5f);
            }

            if (yInput > 0 && xInput == 0)
            { movement.Set(0, 1); animator.SetFloat("SpeedX", 0); animator.SetFloat("SpeedY", yInput); }
            if (yInput < 0 && xInput == 0)
            { movement.Set(0, -1); animator.SetFloat("SpeedX", 0); animator.SetFloat("SpeedY", yInput); }

            //Movement
            body.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.deltaTime), (transform.position.y + movement.y * speed * Time.deltaTime)));
        }
        else
        {
            animator.SetFloat("SpeedY", yInput);
            animator.SetFloat("SpeedX", xInput);
        }
    }
}
