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
	        Instantiate(Resources.Load("Player"));
	    }
	    else
	    {
            Cursor.SetCursor();
	        Debug.Log("Blondin");
            Instantiate(Resources.Load("blondin"));
        }

	    gameObject.AddComponent<CameraController>().entity = GameObject.FindGameObjectWithTag("Player");

	    if (StaticVariables.CoffreSousSolOuvert)
	    {
	        GameObject obj = GameObject.Find("rockfirstlvl");
	        if (obj != null)
	        {
                Destroy(obj);
	        }
	    }

        if (StaticVariables.CowboyChapeau)
            GameObject.Find("Gun").GetComponent<Weapon>().FireRate = StaticVariables.WeaponDamage;
    }
	
    
}
