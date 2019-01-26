using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PhysicStuff : MonoBehaviour
{

	private ParticleSystem impactParticles;

    protected virtual void Start()
    {
	    impactParticles = Instantiate(MessManager.Instance.particleContainer.impactParticles, transform);
    }

	protected virtual void Update()
    {
        
    }

	protected virtual void FixedUpdate()
	{
		
	}

	protected virtual void OnCollisionEnter(Collision other)
	{
		ContactPoint contact = other.GetContact(0);
		if (other.relativeVelocity.sqrMagnitude < MessManager.Instance.data.hurtImpactSpeed) return;

		AudioMaster.Instance.PlayImpactsound();
		impactParticles.transform.position = contact.point;
		//impactParticles.transform.LookAt(collPoint);
		impactParticles.Play();
	}

	protected  virtual void OnCollisionExit(Collision other)
	{
		
	}

	//Use this function to put two things together
	protected virtual void ItsGettingSerious(GameObject collidedObject)
	{

	}

}
