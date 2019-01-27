using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour {

	public GameObject prefab;
	public Transform spawnTransform;

	public float countdown = 0.0f;

	public Rigidbody door1;
	public Rigidbody door2;

	public Vector3 spawnForce;
	
	public void Play () {
		StartCoroutine (StartCountdown());
	}
	
	private IEnumerator StartCountdown () {
		yield return new WaitForSeconds (countdown);
		Spawn ();
	}

	[ContextMenu ("Spawn")]
	protected virtual void Spawn() {
		if (door1)
			door1.isKinematic = false;
		if (door2)
			door2.isKinematic = false;
		Rigidbody character = (Instantiate (prefab, spawnTransform.position, spawnTransform.rotation, null)).GetComponentInChildren<Rigidbody>();
		if (character)
			character.AddForce (transform.rotation * spawnForce, ForceMode.Impulse);
	}

	public void ResetSpawn() {
		if (door1)
			door1.isKinematic = true;
		if (door2)
			door2.isKinematic = true;
	}
}
