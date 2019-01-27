using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	[SerializeField] private float xRotationForce = 3f;
	[SerializeField] private float zRotationForce = 3f;
	[SerializeField] private float cameraRotationSpeed = 0.2f;

	private Quaternion targetRotation;

	[SerializeField] private Animator animator;

	private void Start () {
		animator.Play ("CameraAnimation", -1, 1);
	}

	private void Update () {
		Vector3 acc = Input.acceleration.normalized;
		acc = new Vector3 (acc.z * xRotationForce, 0, -acc.x * zRotationForce);
		targetRotation
			= Quaternion.Euler (acc);
		transform.rotation
			= Quaternion.Lerp (transform.rotation, targetRotation, cameraRotationSpeed);
	}

	[ContextMenu("ZoomIn")]
	public void ZoomIn () {
		animator.SetFloat ("Direction", -1);
		animator.Play ("CameraAnimation", -1, 1);
	}

	[ContextMenu ("ZoomOut")]
	public void ZoomOut () {
		animator.SetFloat ("Direction", 1);
		animator.Play ("CameraAnimation", -1, 0);
	}
}
