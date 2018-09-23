using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelSign : MonoBehaviour, IInteract
{

    private RPGTalk sign;

	// Use this for initialization
	void Start ()
	{
	    sign = GetComponent<RPGTalk>();
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
        sign.NewTalk("sign1_s", "sign1_e");
    }
}
