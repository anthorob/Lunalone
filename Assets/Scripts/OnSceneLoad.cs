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
	        GameObject.Find("Gun").GetComponent<Weapon>().FireRate = StaticVariables.WeaponDamage;
        }
	    else
	    {
            
	        Debug.Log("Blondin");
            Instantiate(Resources.Load("blondin"));
        }

	    gameObject.AddComponent<CameraController>().entity = GameObject.FindGameObjectWithTag("Player");
	    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, -2);

        if (StaticVariables.CoffreSousSolOuvert)
	    {
	        GameObject obj = GameObject.Find("rockfirstlvl");
	        if (obj != null)
	        {
                Destroy(obj);
	        }
	    }

	    switch (SceneManager.GetActiveScene().name)
	    {
            case "HouseInterior":
                OnInteriorEnter();
                break;

            case "HouseUnderground":
                OnUndergroundEnter();
                break;

            case "MainMap":
                OnMainMapEnter();
                break;
	    }

    }

    void OnInteriorEnter()
    {
        if (!StaticVariables.InteriorTextShown)
        {
            GameObject.Find("TextInterior").GetComponent<RPGTalk>().NewTalk("", "");
            StaticVariables.InteriorTextShown = true;
        }
    }

    void OnUndergroundEnter()
    {

    }

    void OnMainMapEnter()
    {
        if (!StaticVariables.FirstTextShown)
        {
            Debug.Log("spawn -2 -33");
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-2, -33);
            RecenterCameraToPlayer();
        }
    }

    void RecenterCameraToPlayer()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        gameObject.GetComponent<Camera>().transform.position = new Vector3(pos.x, pos.y, -10);
    }
}
