using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CameraManager))]
public class MenuShakeDetection : MonoBehaviour {
	float accelerometerUpdateInterval = 1.0f / 60.0f;
	public float lowPassKernelWidthInSeconds = 1.0f;
	public float shakeDetectionThreshold = 4.0f;

	private float lowPassFilterFactor;
	private Vector3 lowPassValue = Vector3.zero;
	private Vector3 acceleration;
	private Vector3 deltaAcceleration;

	private CameraManager cameraManager;

	private bool playing = false;
	
	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;

		cameraManager = GetComponent<CameraManager> ();
	}

	void Update () {
		if (playing)
			return;
		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp (lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;
		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold) {
			PlayGame ();
		}
	}

	void PlayGame() {
		foreach(var hs in FindObjectsOfType<HumanSpawner>()) {
			hs.Play ();
		}
		cameraManager.ZoomIn ();
	}
}
