using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 10;
    private Vector2 target;

    void Start() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if (transform.position.Equals(target))
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<EnemyController>().Health -= 1;
            collider.gameObject.GetComponent<EnemyController>().CheckDeath();
            Destroy(gameObject);
        }
    }
}
