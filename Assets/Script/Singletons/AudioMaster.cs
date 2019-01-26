using System.Collections;
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

	public void PlayVoiceSound(int index)
	{
		AudioSource.PlayClipAtPoint(Instance.soundContainer.voices[index], Vector3.zero);
	}

	public void PlayImpactsound()
	{
		AudioSource.PlayClipAtPoint(Instance.soundContainer.impactSound, Vector3.zero);
	}
	
}
