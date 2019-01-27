using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
	public bool isStatic;
	private new Rigidbody rigidbody;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.isKinematic = true;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (isStatic)
		{

		}
		else
		{
			rigidbody.isKinematic = false;
		}
	}
}
