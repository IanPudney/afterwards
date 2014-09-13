using UnityEngine;
using System.Collections;

public class Deflect : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		other.GetComponent<Laser>().dir = -other.GetComponent<Laser>().dir*2;
	}
}
