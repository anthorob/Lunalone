using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class UndergroundChest : MonoBehaviour, IInteract
{
    private RPGTalk talk;

	// Use this for initialization
	void Start ()
	{
	    talk = GetComponent<RPGTalk>();
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
            Vector2 position = GameObject.FindGameObjectWithTag("Player").transform.position;

            GameObject.Find("Main Camera").GetComponent<CameraController>().entity = null;
            Destroy(GameObject.Find("Main Camera").GetComponent<CameraController>());
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(Resources.Load("Player"));
            StaticVariables.CowboyChapeau = true;
            Invoke("AddCameraControllerBack", 3);

            talk.NewTalk("car_change_s", "car_change_e");

            StaticVariables.CoffreSousSolOuvert = true;

            
        }
            
        

    }

    private void AddCameraControllerBack()
    {
        GameObject.Find("Main Camera").AddComponent<CameraController>().entity = GameObject.FindGameObjectWithTag("Player");
    }

}
