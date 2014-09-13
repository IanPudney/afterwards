using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public Transform target;
	public float speed = 1f;
	public Vector3 dir;

	// Use this for initialization
	void Start () {
		Vector3 v1 = new Vector3 (target.position.x,target.position.y+2,target.position.z);
		dir = v1 - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(dir * speed * Time.deltaTime, Space.World);
	}
}
