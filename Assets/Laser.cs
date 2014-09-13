using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public Transform target;
	public float speed = 1f;
	public Vector3 dir;

	// Use this for initialization
	void Start () {
		dir = target.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(dir * speed * Time.deltaTime, Space.World);
	}
}
