using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float FireRate;
    public float Damage;
    public float RotationSpeed = 5f;
    public float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;
    public LayerMask ToHit;
    public GameObject BulletTrail;

    private float timeToFire = 0;
    private Transform firepoint;

	void Awake() {
		firepoint = transform.FindChild("Firepoint");

        if (firepoint == null)
            Debug.Log("No firepoint detected");
	}
	
	// Update is called once per frame
	void Update () {
        Orientation();
		if (FireRate == 0) {
            if (Input.GetButtonDown("Fire1")) {
                Shoot();
            }
        }
        else {
            if (Input.GetButton("Fire1") && Time.time > timeToFire) {
                timeToFire = Time.time + 1/FireRate;
                Shoot();
            }
        }
    }

    private void Shoot() {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firepoint.position.x, firepoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, ToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100);

        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    private void Effect() {
        Instantiate(BulletTrail, firepoint.position, firepoint.rotation);
    }

    private void Orientation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    }
}
