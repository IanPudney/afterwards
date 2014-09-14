using UnityEngine;
using System.Collections;

public class StickOfPointing : MonoBehaviour {
	public Blade blade;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,
		                                             blade.transform.eulerAngles.y - offset.y,
		                                             transform.rotation.eulerAngles.z));
	}
}
