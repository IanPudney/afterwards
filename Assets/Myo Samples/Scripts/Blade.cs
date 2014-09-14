using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
using System;


public class Blade : MonoBehaviour
{
	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;
	public static int deflected = 0;
	public static int hit = 0;
	public float gameTime;
	private float gameTimeRemaining;
	public TextMesh scoreText;

	public int state = 0; //0=retracted, 1=extending, 2=extended, 3=retracting

	
	// Materials to change to when poses are made.
	public Material waveInMaterial;
	public Material waveOutMaterial;
	public Material thumbToPinkyMaterial;
	
	// The pose from the last update. This is used to determine if the pose has changed
	// so that actions are only performed upon making them rather than every frame during
	// which they are active.
	private Pose _lastPose = Pose.Unknown;

	void Start ()
	{
		gameTimeRemaining = gameTime;
	}

	// Update is called once per frame.
	void Update ()
	{
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		if (thalmicMyo.pose != _lastPose || Input.GetKey ("p")) {
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a fist is made.
			if (!JointOrientation.gameRunning &&
				(thalmicMyo.pose == Pose.Fist || Input.GetKey("p"))) {
				thalmicMyo.Vibrate (VibrationType.Medium);
				state = 1;
				audio.Play ();
				JointOrientation.gameRunning = true;

			} 
		}
		if (JointOrientation.gameRunning) {
			gameTime -= Time.deltaTime;
			if(gameTime < 0) {
				scoreText.text = (deflected).ToString() + " Blocks\r\n" + 
					(hit).ToString () + " Hits";
				JointOrientation.gameRunning = false;
			}
		}
		Extend ();
	}

	void Extend () {
		if (state == 1) {
			if (nearlyEqual(transform.localScale.y, 3.0, 0.01)) {
				state = 2;
			} else {
				Vector3 newScale = new Vector3(transform.localScale.x,
				                               (float)(transform.localScale.y + 0.1),
				                               transform.localScale.z);
				transform.localScale = newScale;
				Vector3 newPosition = new Vector3(transform.localPosition.x,
				                                  (float)(transform.localPosition.y + 0.1),
				                                  transform.localPosition.z);
				transform.localPosition = newPosition;
			}
		}
	}

	void Retract () {

	}



	public static bool nearlyEqual(double a, double b, double maxDiff) {
		double diff = Math.Abs(a - b);
		
		if (a == b) { // shortcut, handles infinities
			return true;
		} 
		if (diff < maxDiff) {
				return true;
		}
		return false;
	}
}
