using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PhysicStuff : MonoBehaviour
{
    protected virtual void Start()
    {
        
    }

	protected virtual void Update()
    {
        
    }

	protected virtual void FixedUpdate()
	{
		
	}

	protected virtual void OnCollisionEnter(Collision other)
	{
		AudioMaster.Instance.PlayImpactsound();
	}

	protected  virtual void OnCollisionExit(Collision other)
	{
		
	}

	//Use this function to put two things together
	protected virtual void ItsGettingSerious(GameObject collidedObject)
	{

	}

}
