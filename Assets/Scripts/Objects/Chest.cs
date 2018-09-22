using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteract
{
    private Animator anim;

    public bool IsInteractable()
    {
        return true;
    }

    public void TryInteract()
    {
        Debug.Log("ChestInteract");
        anim.SetBool("doOpening", true);
    }

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
