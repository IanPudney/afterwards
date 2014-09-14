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
	public float  minimum = 0.03f;
	void Start () {
		velocity = Vector3.zero;
		initialPos = transform.position;
		timeUntilShot = shotInterval;
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//bounce
		if (JointOrientation.gameRunning) {
				renderer.enabled = true;
				velocity += Random.insideUnitSphere * speed;
				velocity = new Vector3 (velocity.x,
                       velocity.y,
                       0);
				transform.position += velocity;
				Vector3 radiusVector = transform.position - initialPos;
				if (radiusVector.magnitude > 10) {
						transform.position -= velocity;
						float magnitude = velocity.magnitude;
						velocity = Random.insideUnitSphere * magnitude;
				}

				//shot
				timeUntilShot -= Time.deltaTime;
				if (timeUntilShot < 0) {
						GameObject l = (GameObject)Instantiate (laser, transform.position, Quaternion.identity);
						l.GetComponent<Laser> ().target = target.transform;
						timeUntilShot += shotInterval;
						
						shotInterval *= 0.97f;
						
						if(shotInterval < minimum){
							shotInterval = minimum;
						}
			}
		}
	}
}
