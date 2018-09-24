using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using RPGTALK.Helper;
using UnityEngine;

public class FirstLevelChest : MonoBehaviour, IInteract, ITalk
{
    private bool isTalking = false;
    private bool alreadyTaken = false;
    private RPGTalk talk;

    public bool IsInteractable()
    {
        return true;
    }

    public void TryInteract()
    {
        if (!alreadyTaken)
        {
            Weapon w = GameObject.Find("Gun").GetComponent<Weapon>();
            w.FireRate = StaticVariables.WeaponDamage = 10;

            StartTalking();

            alreadyTaken = true;
        }
    }


    // Use this for initialization
    void Start ()
    {
        talk = GetComponent<RPGTalk>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTalking()
    {
        if (!isTalking)
        {
            talk.NewTalk("flevel_start", "flevel_end");
            isTalking = true;
        }
    }

    public void StopTalking()
    {
        isTalking = false;
    }
}
