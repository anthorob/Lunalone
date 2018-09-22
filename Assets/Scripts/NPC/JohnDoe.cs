using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Interface;
using UnityEngine;

public class JohnDoe : MonoBehaviour, IInteract {
    public bool IsInteractable()
    {
        return true;
    }

    public void TryInteract()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
