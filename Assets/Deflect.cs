using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
using System;
public class Deflect : MonoBehaviour {

	public GameObject myo = null;

	void OnTriggerEnter(Collider other) {

		other.GetComponent<Laser>().dir = -other.GetComponent<Laser>().dir*2;
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		try {
			thalmicMyo.Vibrate (VibrationType.Short);
		} catch (NullReferenceException ex) {
			/*...*/
		}

	}
}
