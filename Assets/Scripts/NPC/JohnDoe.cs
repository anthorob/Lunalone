using UnityEngine;

public class JohnDoe : MonoBehaviour, IInteract, ITalk
{

    private RPGTalk talk;

    public bool IsInteractable()
    {
        return true;
    }

    public void TryInteract()
    {
        talk.NewTalk("npc1_start", "npc1_end");
    }

    // Use this for initialization
    void Start () {
        talk = GameObject.FindGameObjectWithTag("rpgtalk").GetComponent<RPGTalk>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTalking()
    {
        throw new System.NotImplementedException();
    }

    public void StopTalking()
    {
        throw new System.NotImplementedException();
    }
}
