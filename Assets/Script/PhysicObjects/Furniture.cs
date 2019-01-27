using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour {
	public bool isStatic;
	public bool hurt;
	private new Rigidbody rigidbody;
	private int colls;
	[SerializeField] private int collisionToMove;
	private Transform startTransform;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		startTransform.position = transform.position;
		startTransform.rotation = transform.rotation;
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
		transform.position = startTransform.position;
		transform.rotation = startTransform.rotation;
	}
}
