using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PhysicStuff : MonoBehaviour
{
	public enum CollisionType
	{
		Neutral, Love, Hurt
	}
	private ParticleSystem hurtParticles;
	private ParticleSystem loveParticles;

	protected new Rigidbody rigidbody;

    protected virtual void Start()
    {
	    hurtParticles = 
		    Instantiate(MessManager.Instance.particleContainer.hurtParticles, transform);
	    loveParticles =
		    Instantiate(MessManager.Instance.particleContainer.loveParticles, transform);
		rigidbody = GetComponent<Rigidbody>();
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
		if (other.relativeVelocity.sqrMagnitude < MessManager.Instance.data.softImpactSpeed) return;

		switch (GetCollisionType(other.gameObject))
		{
			case CollisionType.Neutral:
				GameObject part = MessManager.Instance.neutralParticlePool.GetPooledObject();
				part.transform.position = contact.point;
				part.SetActive(true);
				break;
			case CollisionType.Love:
				loveParticles.Play();
				break;
			case CollisionType.Hurt:
				hurtParticles.Play();
				break;
		}


		AudioMaster.Instance.PlayImpactsound();
	}

	protected  virtual void OnCollisionExit(Collision other)
	{

		hurtParticles.Stop();
	}

	//Use this function to put two things together
	protected virtual void ItsGettingSerious(GameObject collidedObject)
	{

	}

	private CollisionType GetCollisionType(GameObject other)
	{
		if (MessManager.Instance.furnitureLayer
		    == (MessManager.Instance.furnitureLayer | (1 << other.layer)))
		{
			//It's a furniture
			return other.GetComponent<Furniture>().type;
		}

		if (MessManager.Instance.humanLayer
		         == (MessManager.Instance.humanLayer | (1 << other.layer)))
		{
			return CollisionType.Love;
		}

		//It's a wall
		return CollisionType.Neutral;
	}

}
