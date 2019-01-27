using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : PhysicStuff
{

	[SerializeField] private ParticleSystem surpriseParticles;
	private int identity;
	private float arouseFactor;
	private float lastArouseFactor;
	private float timeSinceLastContact;
	private float timeSinceLastSound;
	private float stopSekstime = 3f;

	private float softSeksValue = 10f;
	private float hardSeksValue = 30f;

	// Start is called before the first frame update
	protected override void Start()
	{
		base.Start();
		identity = Random.Range(0, 
			AudioMaster.Instance.soundContainer.GetVoiceRange());

		SkinnedMeshRenderer[] skin = 
			transform.root.GetComponentsInChildren<SkinnedMeshRenderer>();
		Color skinCol = MessManager.Instance.colorContainer.GetRandColor();
		for (int i = 0; i < skin.Length; i++)
		{
			skin[i].material.color = skinCol;
		}

		StartCoroutine(PlayHelloWithDelay());
	}

	private IEnumerator PlayHelloWithDelay()
	{
		yield return new WaitForSeconds(Random.Range(0f, 2.0f));
		AudioMaster.Instance.PlayHelloSound(identity);
	}

	protected override void Update()
	{
		if (arouseFactor == 0f) return;

		if (Time.time - timeSinceLastContact > stopSekstime)
		{
			arouseFactor = 0f;
			AudioMaster.Instance.PlayStopSexSound(identity);
		}
	}

	private void CheckArousedFactor(ContactPoint contact)
	{
		if (Time.time - timeSinceLastSound < Random.Range(0.5f, 2f)) return;
		//Soft Seks
		if (arouseFactor >= hardSeksValue)
		{
			AudioMaster.Instance.PlayHardSexSound(identity);
			timeSinceLastSound = Time.time;
		}
		else if (arouseFactor >= softSeksValue)
		{
			//First time Seks
			if (lastArouseFactor < softSeksValue)
			{
				AudioMaster.Instance.PlaySurprisedSound(identity);
				timeSinceLastSound = Time.time;
				surpriseParticles.Play();
			}
			else
			{
				AudioMaster.Instance.PlaySoftSexSound(identity);
				timeSinceLastSound = Time.time;
			}
		}
		else
		{
			//Just touched
			AudioMaster.Instance.PlayTouchedSound(identity);
			timeSinceLastSound = Time.time;
		}

		lastArouseFactor = arouseFactor;

		loveParticles.transform.position = transform.position;
		loveParticles.transform
			.LookAt(loveParticles.transform.position - contact.point, Vector3.up);
		loveParticles.Play();
	}

	protected override void OnCollisionEnter(Collision other)
	{
		float arouseContactRatio = 0f;
		base.OnCollisionEnter(other);
		ContactPoint contact = other.GetContact(0);
		if (other.relativeVelocity.sqrMagnitude < MessManager.Instance.data.softImpactSpeed) return;

		if (other.relativeVelocity.sqrMagnitude >= MessManager.Instance.data.hurtImpactSpeed)
			arouseContactRatio = 3f;
		else
			arouseContactRatio = 1f;

		switch (GetCollisionType(other.gameObject))
		{
			case CollisionType.Love:
				timeSinceLastContact = Time.time;
				arouseFactor += arouseContactRatio;
				CheckArousedFactor(contact);
				break;

			case CollisionType.Hurt:
				if (Time.time - timeSinceLastSound < Random.Range(0.5f, 2f)) return;
				hurtParticles.transform.position = transform.position;
				hurtParticles.transform
					.LookAt(hurtParticles.transform.position - contact.point, Vector3.up);
				hurtParticles.Play();
				AudioMaster.Instance.PlayHurtSound(identity);
				timeSinceLastSound = Time.time;
				break;
		}
	}

}
