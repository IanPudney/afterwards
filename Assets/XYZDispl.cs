using UnityEngine;
using System.Collections;

public class XYZDispl : MonoBehaviour {
	
	public Blade blade;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		TextMesh me = gameObject.GetComponent<TextMesh> ();
		me.text = "X: " + blade.transform.eulerAngles.x + "\r\n" +
			      "Y: " + blade.transform.eulerAngles.y + "\r\n" +
				  "Z: " + blade.transform.eulerAngles.z;
	}
}
