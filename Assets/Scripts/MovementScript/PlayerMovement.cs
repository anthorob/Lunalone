﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float speed;
    public int health;
    public Animator animator;

    private Rigidbody2D body;
    void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	public void FixedUpdate()
	{
        HandleMouvement();
        
    }

    private void HandleMouvement()
    {
        //Check if player is moving 
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        bool isMovingX = Mathf.Abs(xInput) > 0.5;
        bool isMovingY = Mathf.Abs(yInput) > 0.5;

        if (isMovingX || isMovingY)
        {
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 1);
            Vector2 movement = new Vector2(0, 0);

            if (xInput > 0) // Right up/down movement
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

            if (xInput < 0) // Left up/down movement
            {
                //Check rotation of gun sprite

                animator.SetFloat("SpeedY", 0);
                animator.SetFloat("SpeedX", xInput);
                if (yInput == 0)
                    movement.Set(-1, 0);
                else if (yInput > 0)
                    movement.Set(-1, .5f);
                else
                    movement.Set(-1, -.5f);
            }

            if (yInput > 0 && xInput == 0) // UP
            {
                movement.Set(0, 1);
                animator.SetFloat("SpeedX", 0);
                animator.SetFloat("SpeedY", yInput);
            }
            if (yInput < 0 && xInput == 0) // Down
            {
                movement.Set(0, -1);
                animator.SetFloat("SpeedX", 0);
                animator.SetFloat("SpeedY", yInput);
            }

            //Movement
            body.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.deltaTime), (transform.position.y + movement.y * speed * Time.deltaTime)));
        }
        else
        {
            animator.SetLayerWeight(0, 1);
            animator.SetLayerWeight(1, 0);
            animator.SetFloat("SpeedY", yInput);
            animator.SetFloat("SpeedX", xInput);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            health--;
            Destroy(collision.gameObject);
            CheckDeath();
        }

    }

    private  void CheckDeath()
    {
        if (health == 0)
        {
            StaticVariables.CoffreSousSolOuvert = false;
            StaticVariables.CowboyChapeau = false;
            StaticVariables.FirstTextShown = false;
            StaticVariables.FirstWaveCompleted = false;
            StaticVariables.InteriorTextShown = false;
            StaticVariables.Level1SpawnEnnemi = false;
            StaticVariables.WeaponDamage = 0;

            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
            

    }
}
