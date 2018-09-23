using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class BaseChest : MonoBehaviour, IInteract
{
    private bool alreadyTaken;
    private Animator anim;

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
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

            anim.SetBool("doChestOpening", true);
            Invoke("StopAnim", 1f);

            StaticVariables.CoffreSousSolOuvert = true;
        }
    }

    private void StopAnim()
    {
        anim.SetBool("doChestOpening", false);
    }
}
