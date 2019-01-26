using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class GravityManager : MonoBehaviour {

	private Vector3 acceleration;
	private Vector3 deltaAcceleration = Vector3.zero;

	private Rigidbody rb;

	public float gravityScale = 9.81f;
	public float deltaScale = 1.0f;

	public Vector3 velocity;

	public AnimationCurve movement;

	void Start () {
		rb = GetComponent<Rigidbody> ();

		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.Landscape;

		UpdateAcceleration ();
	}

	void UpdateAcceleration() {
		acceleration = Input.acceleration;
	}

	void Update () {
		Vector3 lastAcceleration = acceleration;

		UpdateAcceleration ();

		acceleration = new Vector3 (acceleration.x, acceleration.y, -acceleration.z);

		deltaAcceleration = acceleration - lastAcceleration;
		float mag = deltaAcceleration.magnitude / 10.0f;
		deltaAcceleration *= (mag * mag) * 10.0f;
	}

	private void FixedUpdate () {
		Physics.gravity = acceleration * gravityScale;

		//rb.AddForce (deltaAcceleration * deltaScale, ForceMode.VelocityChange);
		rb.velocity = deltaAcceleration * deltaScale;

		movement.AddKey (Time.unscaledTime, deltaAcceleration.magnitude);
	}
}
