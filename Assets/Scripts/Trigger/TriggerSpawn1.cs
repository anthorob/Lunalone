using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class TriggerSpawn1 : MonoBehaviour, IInteract {

	// Use this for initialization
	void Start () {
		
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
        if (StaticVariables.CoffreSousSolOuvert)
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }

        
    }

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int maxEnemy;
    private int enemySpawned;

    void Spawn()
    {
        if (enemySpawned < maxEnemy)
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemySpawned++;
        }
    }
}
