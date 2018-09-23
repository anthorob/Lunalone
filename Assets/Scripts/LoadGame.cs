using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag("BtnPlay").GetComponent<Button>().onClick.AddListener(OnClickPlay);
	}

    void OnClickPlay()
    {
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
    }
}
