using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public Transform target;
	public float speed = 1f;
	public Vector3 dir;
	private bool hasHit = false;

	// Use this for initialization
	void Start () {
		Vector3 v1 = new Vector3 (target.position.x,target.position.y,target.position.z);
		dir = v1 - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(dir * speed * Time.deltaTime, Space.World);
		if (!hasHit && Vector3.Distance (target.position, transform.position) < 1f) {
			Debug.Log ("Hit!");
			speed = 0.0f;
			particleSystem.Play();
			this.audio.Play();
			renderer.enabled = false;
			hasHit = true;
			Blade.hit += 1;
		}

	}
}
