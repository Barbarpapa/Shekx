using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : PhysicStuff
{
	[SerializeField]
	private int identity;

	private Material skin;

    // Start is called before the first frame update
	protected override void Start()
	{
		base.Start();
		identity = Random.Range(0, AudioMaster.Instance.soundContainer.GetVoiceRange());

		//skin = GetComponentInChildren<MeshRenderer>().material;

		//skin.color = MessManager.Instance.colorContainer.GetRandColor();

		StartCoroutine(PlayHelloWithDelay());
	}

	private IEnumerator PlayHelloWithDelay()
	{
		yield return new WaitForSeconds(Random.Range(0f, 2.0f));
		AudioMaster.Instance.PlayHelloSound(identity);

	}

	protected override void OnCollisionEnter(Collision other)
	{
		base.OnCollisionEnter(other);
		ContactPoint contact = other.GetContact(0);
		if (other.relativeVelocity.sqrMagnitude < MessManager.Instance.data.softImpactSpeed) return;

		switch (GetCollisionType(other.gameObject))
		{
			case CollisionType.Love:
				loveParticles.transform.position = transform.position;
				loveParticles.transform
					.LookAt(loveParticles.transform.position - contact.point, Vector3.up);
				loveParticles.Play();
				AudioMaster.Instance.PlayTouchedSound(identity);
				break;
			case CollisionType.Hurt:
				hurtParticles.transform.position = transform.position;
				hurtParticles.transform
					.LookAt(hurtParticles.transform.position - contact.point, Vector3.up);
				hurtParticles.Play();
				AudioMaster.Instance.PlayHurtSound(identity);
				break;
		}
	}

	protected override void OnCollisionExit(Collision other)
	{
		base.OnCollisionExit(other);
	}



}
