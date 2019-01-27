using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (CameraManager))]
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

	[SerializeField]
	CanvasGroup menuGroup;
	[SerializeField]
	CanvasGroup creditsGroup;

	public static bool humansCollided = false;
	private bool spawnersStarted = false;

	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		lowPassValue = Input.acceleration;

		cameraManager = GetComponent<CameraManager> ();
	}

	void Update () {
		if (playing) {
			if (humansCollided) {
				StartSpawners ();
			}
		}
		else {
			acceleration = Input.acceleration;
			lowPassValue = Vector3.Lerp (lowPassValue, acceleration, lowPassFilterFactor);
			deltaAcceleration = acceleration - lowPassValue;
			if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold) {
				PlayGame ();
			}
		}
	}

	void PlayGame () {
		playing = true;
		cameraManager.ZoomIn ();
		StartCoroutine (FadeGroup (menuGroup, 0.0f));
	}

	void StartSpawners() {
		if (spawnersStarted)
			return;
		spawnersStarted = true;
		foreach (var hs in FindObjectsOfType<HumanSpawner> ()) {
			hs.Play ();
		}
	}

	void EndGame () {
		StartCoroutine (FadeGroup (creditsGroup, 1.0f));
		spawnersStarted = false;
		humansCollided = false;
		playing = false;
	}

	private IEnumerator FadeGroup (CanvasGroup cg, float value, float fadeTime = 2.0f) {
		float endTime = Time.time + fadeTime;
		float startAlpha = cg.alpha;
		while (endTime >= Time.time) {
			cg.alpha = Mathf.Lerp (value, startAlpha, (endTime - Time.time) / fadeTime);
			yield return null;
		}
		cg.alpha = value;
	}
}
