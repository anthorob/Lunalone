using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int Health = 5;

    private Rigidbody2D body;

    public Transform target;
    public GameObject projectile;
    public float speed = 3f;
    public float rotationSpeed = 2f;
    public float attack1Range = 1f;
    public float timeToFire = 1f;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            Destroy(collider.gameObject);
            Health--;
            CheckDeath();
            Debug.Log(Health);
        }
    }
    public void CheckDeath()
    {
        if (Health == 0)
            Destroy(gameObject);
    }

    public void MoveToPlayer()
    {
        Vector3 displacement = GameObject.FindWithTag("Player").transform.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > attack1Range)
        {
            transform.position += (displacement * speed * Time.deltaTime);

        }
        else
        {
            if (Time.time > timeToFire)
            {
                EnemyShoot();
                timeToFire = Time.time + 1 ;
            }
        }
    }

    private void EnemyShoot()
    {
        GameObject player = GameObject.Find("Player(Clone)");
        if (player != null)
        {
            GameObject bullet = Instantiate(projectile);
            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet.transform.position;
            bullet.transform.TransformDirection(direction);
        }
    }
}

