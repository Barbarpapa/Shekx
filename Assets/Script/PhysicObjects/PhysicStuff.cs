using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicStuff : MonoBehaviour
{
	public enum CollisionType
	{
		Neutral, Love, Hurt
	}
	protected ParticleSystem hurtParticles;
	protected ParticleSystem loveParticles;

	protected new Rigidbody rigidbody;

    protected virtual void Start()
    {
	    hurtParticles = 
		    Instantiate(MessManager.Instance.particleContainer.hurtParticles, null);
	    loveParticles =
		    Instantiate(MessManager.Instance.particleContainer.loveParticles, null);
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

		//switch (GetCollisionType(other.gameObject))
		//{
		//	case CollisionType.Neutral:
		//		GameObject part = MessManager.Instance.neutralParticlePool.GetPooledObject();
		//		part.transform.position = contact.point;
		//		part.transform.LookAt(contact.point - part.transform.position, Vector3.up);
		//		part.SetActive(true);
		//		break;
		//}
	}

	protected  virtual void OnCollisionExit(Collision other)
	{
		hurtParticles.Stop();
	}

	//Use this function to put two things together
	protected virtual void ItsGettingSerious(GameObject collidedObject)
	{

	}

	protected CollisionType GetCollisionType(GameObject other)
	{
		//if (MessManager.Instance.furnitureLayer
		//    == (MessManager.Instance.furnitureLayer | (1 << other.layer)))
		//{
		//	//It's a furniture
		//	return other.GetComponent<Furniture>().type;
		//}

		if (MessManager.Instance.humanLayer
		         == (MessManager.Instance.humanLayer | (1 << other.layer)))
		{
			return CollisionType.Love;
		}

		//It's a wall
		return CollisionType.Neutral;
	}

	Vector3 SnapTo(Vector3 v3, float snapAngle)
	{
		float angle = Vector3.Angle(v3, Vector3.up);
		if (angle < snapAngle / 2.0f)          // Cannot do cross product 
			return Vector3.up * v3.magnitude;  //   with angles 0 & 180
		if (angle > 180.0f - snapAngle / 2.0f)
			return Vector3.down * v3.magnitude;

		float t = Mathf.Round(angle / snapAngle);
		float deltaAngle = (t * snapAngle) - angle;

		Vector3 axis = Vector3.Cross(Vector3.up, v3);
		Quaternion q = Quaternion.AngleAxis(deltaAngle, axis);
		return q * v3;
	}

}
