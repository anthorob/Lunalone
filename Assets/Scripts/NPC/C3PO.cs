using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3PO : MonoBehaviour, IInteract
{

    private RPGTalk text;

	// Use this for initialization
	void Start ()
	{
	    text = GetComponent<RPGTalk>();
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
        text.NewTalk("1", "-1");
    }
}
