using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed = 10;
    private GameObject target;
    private Vector3 targetPos;
    private Vector2 moveDirection;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetPos = target.transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ddddd");
    }
}