﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairsSecondFloor : MonoBehaviour, IInteract {

	// Use this for initialization
	void Start () {
		
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
        
        SceneManager.LoadScene("HouseUnderground", LoadSceneMode.Single);
    }
}
