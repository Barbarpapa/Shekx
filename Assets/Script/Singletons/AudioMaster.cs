﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{
	private static AudioMaster instance;
	public static AudioMaster Instance
	{
		get
		{

			if (!(instance is AudioMaster))
			{
				GameObject gO;
				instance = FindObjectOfType<AudioMaster>();

				if (!(instance is AudioMaster))
				{
					gO = Instantiate(Resources.Load("Prefab/Singletons/AudioMaster")) as GameObject;
					instance = gO.GetComponent<AudioMaster>();
				}
				else
				{
					gO = instance.gameObject;
				}
			}
			return instance;
		}
	}

	public SoundContainer soundContainer;


	public void PlayMenuMusic()
	{
<<<<<<< HEAD
		Camera.main.GetComponent<AudioSource>().clip = Instance.soundContainer.menuMusic;
		Camera.main.GetComponent<AudioSource>().Play();
=======
		AudioSource.PlayClipAtPoint(Instance.soundContainer.menuMusic, transform.position);
>>>>>>> parent of 3a9de47... Merge branch 'master' of https://github.com/Barbarpapa/Shekx
	}

	public void PlayGameMusic()
	{
<<<<<<< HEAD
		Camera.main.GetComponent<AudioSource>().clip = Instance.soundContainer.gameMusic;
		Camera.main.GetComponent<AudioSource>().Play();
=======
		AudioSource.PlayClipAtPoint(Instance.soundContainer.gameMusic, transform.position);
>>>>>>> parent of 3a9de47... Merge branch 'master' of https://github.com/Barbarpapa/Shekx
	}

	public void PlayHelloSound(int index)
	{
		AudioSource.PlayClipAtPoint(Instance.soundContainer.humanSoundbank[index].hello, transform.position);
	}

	public void PlayHardSexSound(int index)
	{
		int rand = Random.Range(0, Instance.soundContainer.humanSoundbank[index].hardSex.Count);
		AudioSource
			.PlayClipAtPoint(
				Instance.soundContainer.humanSoundbank[index].hardSex[rand],
				transform.position);
	}

	public void PlaySoftSexSound(int index)
	{
		int rand = Random.Range(0, Instance.soundContainer.humanSoundbank[index].softSex.Count);
		AudioSource
			.PlayClipAtPoint(
				Instance.soundContainer.humanSoundbank[index].softSex[rand],
				transform.position);
	}

	public void PlayStopSexSound(int index)
	{
		int rand = Random.Range(0, Instance.soundContainer.humanSoundbank[index].stopSex.Count);
		AudioSource
			.PlayClipAtPoint(
				Instance.soundContainer.humanSoundbank[index].stopSex[rand],
				transform.position);
	}

	public void PlayHurtSound(int index)
	{
		int rand = Random.Range(0, Instance.soundContainer.humanSoundbank[index].hurt.Count);
		AudioSource
			.PlayClipAtPoint(
				Instance.soundContainer.humanSoundbank[index].hurt[rand],
				transform.position);
	}

	public void PlaySurprisedSound(int index)
	{
		int rand = Random.Range(0, Instance.soundContainer.humanSoundbank[index].surprised.Count);
		AudioSource
			.PlayClipAtPoint(
				Instance.soundContainer.humanSoundbank[index].surprised[rand],
				transform.position);
	}

	public void PlayTouchedSound(int index)
	{
		int rand = Random.Range(0, Instance.soundContainer.humanSoundbank[index].touched.Count);
		AudioSource
			.PlayClipAtPoint(
				Instance.soundContainer.humanSoundbank[index].touched[rand],
				transform.position);
	}

}
