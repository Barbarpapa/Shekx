using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : PhysicStuff
{
	[SerializeField]
	private int identity;
	private int contactNum;
	private float arouseFactor;
	private float lastArouseFactor;
	private float timeSinceLastContact;
	private float timeSinceLastSound;
	private float stopSekstime = 3f;

	private float softSeksValue = 10f;
	private float hardSeksValue = 30f;
	public bool debug;

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
			if (debug)
				print("STOP");
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
				if (debug)
					print("SURPRISE");
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
		base.OnCollisionEnter(other);
		ContactPoint contact = other.GetContact(0);
		if (other.relativeVelocity.sqrMagnitude < MessManager.Instance.data.softImpactSpeed) return;

		switch (GetCollisionType(other.gameObject))
		{
			case CollisionType.Love:
				timeSinceLastContact = Time.time;
				arouseFactor += 1f;
				CheckArousedFactor(contact);
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
