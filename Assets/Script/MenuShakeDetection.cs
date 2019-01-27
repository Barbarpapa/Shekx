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

	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
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

	void PlayGame () {
		playing = true;
<<<<<<< HEAD
		cameraManager.ZoomIn ();
		StartCoroutine (FadeGroup (menuGroup, 0.0f));
		AudioMaster.Instance.PlayGameMusic();
	}

	void StartSpawners() {
		if (spawnersStarted)
			return;
		spawnersStarted = true;
=======
>>>>>>> parent of 3a9de47... Merge branch 'master' of https://github.com/Barbarpapa/Shekx
		foreach (var hs in FindObjectsOfType<HumanSpawner> ()) {
			hs.Play ();
		}
		cameraManager.ZoomIn ();
		StartCoroutine (FadeGroup (menuGroup, 0.0f));
	}

	void EndGame () {
		StartCoroutine (FadeGroup (creditsGroup, 1.0f));
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
