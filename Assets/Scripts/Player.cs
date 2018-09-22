using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Interface;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Direction direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.E))
	    {
            Entity.ExecuteActionOnInteract(Entity.GetObjectAtSpecifiedDirection(transform, Direction.RIGHT));
            
	    }
	}
}
