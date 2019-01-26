using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : PhysicStuff
{
	public bool isStatic;
	public CollisionType type;

	protected override void Start()
	{
		base.Start();
		rigidbody.isKinematic = true;
	}

	protected override void OnCollisionEnter(Collision other)
	{
		base.OnCollisionEnter(other);
		if (isStatic)
		{

		}
		else
		{
			rigidbody.isKinematic = false;
		}


	}
}
