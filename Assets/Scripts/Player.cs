using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Interface;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class Player : MonoBehaviour
{
    private Direction direction;

    public void OnTriggerEnter2D(Collider2D col)
    {
        Entity.ExecuteActionOnInteract(col.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
            direction = Direction.UP;

	    if (Input.GetKeyDown(KeyCode.S))
	        direction = Direction.DOWN;

	    if (Input.GetKeyDown(KeyCode.A))
	        direction = Direction.LEFT;

	    if (Input.GetKeyDown(KeyCode.D))
	        direction = Direction.RIGHT;

        if (Input.GetKeyDown(KeyCode.E))
        {
            UnityEngine.Debug.Log(Entity.GetObjectAtSpecifiedDirection(transform, direction));
            Entity.ExecuteActionOnInteract(Entity.GetObjectAtSpecifiedDirection(transform, direction));
            
	    }
	}
}
