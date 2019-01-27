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

	public AnimationCurve angleCurve;
	[Range(0, 1)]
	public float angleFactor = 0.5f;

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
		acceleration = new Vector3 (acceleration.x, acceleration.y, -acceleration.z);

		Quaternion q = Quaternion.FromToRotation (Vector3.down, acceleration);
		float angle = Quaternion.Angle (Quaternion.identity, q);
		if (angle > 90.0f)
			angle -= 90.0f;

		q = Quaternion.LerpUnclamped (Quaternion.identity, q, angleCurve.Evaluate (angle / 90.0f) * angleFactor);
		acceleration = q * acceleration;
	}

	void Update () {
		Vector3 lastAcceleration = acceleration;

		UpdateAcceleration ();

		deltaAcceleration = acceleration - lastAcceleration;
		float mag = deltaAcceleration.magnitude / 10.0f;
		deltaAcceleration *= (mag * mag) * 10.0f;
	}

	private void FixedUpdate () {
		//Physics.gravity = acceleration * gravityScale;
		Physics.gravity = Vector3.down * gravityScale;

		//rb.AddForce (deltaAcceleration * deltaScale, ForceMode.VelocityChange);
		rb.velocity = deltaAcceleration * deltaScale;
	}
}
