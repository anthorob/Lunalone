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
	        Instantiate(Resources.Load("Player"));
	    }
	}
	
}
