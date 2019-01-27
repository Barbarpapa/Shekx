using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour {
	public bool isStatic;
	public bool hurt;
	private new Rigidbody rigidbody;

	private Transform startTransform;

	private void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.isKinematic = true;
		startTransform.position = transform.position;
		startTransform.rotation = transform.rotation;
	}

	private void OnCollisionEnter (Collision other) {
		if (isStatic) {

		}
		else {
			rigidbody.isKinematic = false;
		}
	}

	public void ResetTransform () {
		rigidbody.isKinematic = true;
		transform.position = startTransform.position;
		transform.rotation = startTransform.rotation;
	}
}
