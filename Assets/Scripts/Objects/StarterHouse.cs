using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterHouse : MonoBehaviour, IInteract {

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
        Debug.Log("Enter house");
    }
}
