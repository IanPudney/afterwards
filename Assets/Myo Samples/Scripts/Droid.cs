using UnityEngine;
using System.Collections;

public class Droid : MonoBehaviour {
	public Vector3 velocity;
	private Vector3 initialPos;
	// Use this for initialization
	public float speed;
	public float shotInterval;
	public GameObject laser;
	public GameObject target;
	private float timeUntilShot;
	void Start () {
		velocity = Vector3.zero;
		initialPos = transform.position;
		timeUntilShot = shotInterval;
	}
	
	// Update is called once per frame
	void Update () {
		velocity += Random.insideUnitSphere * speed;
		velocity = new Vector3 (velocity.x,
		                       velocity.y,
		                       0);
		transform.position += velocity;
		if ((transform.position - initialPos).magnitude > 10) {
			velocity *= -1;
			transform.position += 2*velocity;
		}
		timeUntilShot -= Time.deltaTime;
		if (timeUntilShot < 0) {
			GameObject l = (GameObject)Instantiate(laser, transform.position, Quaternion.identity);
			l.GetComponent<Laser>().target = target.transform;
			timeUntilShot += shotInterval;
			shotInterval *= 0.97f;
		}
	}
}
