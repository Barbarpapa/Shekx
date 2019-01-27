using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour {
	public bool isStatic;
	public bool hurt;
	private new Rigidbody rigidbody;
	private int colls;
	[SerializeField] private int collisionToMove;
	private Vector3 basePosition;
	private Quaternion baseRotation;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		basePosition = transform.position;
		baseRotation = transform.rotation;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!isStatic || colls > collisionToMove) return;

		if (MessManager.Instance.humanLayer
		    == (MessManager.Instance.humanLayer | (1 << other.gameObject.layer)))
		{
			colls++;
			if (colls == collisionToMove)
			{
				rigidbody.isKinematic = false;
				isStatic = false;
			}
		}
	}


	public void ResetTransform () {
		rigidbody.isKinematic = true;
		transform.position = basePosition;
		transform.rotation = baseRotation;
	}
}
