using System.Collections;
using System.Collections.Generic;
using RPGTALK.Helper;
using UnityEngine;

public class FirstLevelChest : MonoBehaviour, IInteract, ITalk
{
    private bool isTalking = false;
    private RPGTalk talk;
    private Animator anim;

    public bool IsInteractable()
    {
        return true;
    }

    public void TryInteract()
    {
        Weapon w = GameObject.Find("weapon_gun").GetComponent<Weapon>();
        w.FireRate = 5;

        Debug.Log("ChestInteract");
        anim.SetBool("doChestOpening", true);
        Invoke("StopAnim", 1f);
        StartTalking();
        
    }

    private void StopAnim()
    {
        anim.SetBool("doChestOpening", false);
    }

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
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
