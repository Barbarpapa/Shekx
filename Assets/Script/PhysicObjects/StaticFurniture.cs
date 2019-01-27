using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFurniture : MonoBehaviour
{
	private AudioSource source;
	[SerializeField] private AudioClip[] sounds;
	private float lastTimeCollision;

	private void OnCollisionEnter(Collision other)
	{
		if (Time.time - lastTimeCollision < Random.Range(0.5f, 2f)) return;

		int rand = Random.Range(0, sounds.Length);
		source.PlayOneShot(sounds[rand]);

		lastTimeCollision = Time.time;
	}
}
