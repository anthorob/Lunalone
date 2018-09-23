using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSceneLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {

	    if (StaticVariables.CowboyChapeau)
	    {
            Debug.Log("Chapeau");
	        Instantiate(Resources.Load<GameObject>("Player"));
	    }
	    else
	    {
	        Debug.Log("Blondin");
            Instantiate(Resources.Load<GameObject>("blondin"));
        }

	    gameObject.AddComponent<CameraController>().entity = GameObject.FindGameObjectWithTag("Player");
        GameObject.Find("weapon_gun").GetComponent<Weapon>().FireRate = StaticVariables.WeaponDamage;
    }
	
    
}
