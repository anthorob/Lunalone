﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class UndergroundChest : MonoBehaviour, IInteract
{
    private RPGTalk talk;

	// Use this for initialization
	void Start ()
	{
	    talk = GetComponent<RPGTalk>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsInteractable()
    {
        return true;
    }

    public void TryInteract()
    {
        if (!StaticVariables.CoffreSousSolOuvert)
        {
            Vector2 position = GameObject.FindGameObjectWithTag("Player").transform.position;

            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(Resources.Load("Player"));
            StaticVariables.CowboyChapeau = true;
            RecenterCameraToPlayer();

            talk.NewTalk("car_change_s", "car_change_e");

            StaticVariables.CoffreSousSolOuvert = true;

            
        }
            
        

    }

    void RecenterCameraToPlayer()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        gameObject.GetComponent<Camera>().transform.position = new Vector3(pos.x, pos.y, -10);
    }

}
