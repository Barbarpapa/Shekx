using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "SoundContainer", menuName = "CestLeSHEKS/SoundContainer")]
public class SoundContainer : ScriptableObject
{
	[System.Serializable]
	public struct HumanSounds
	{
		public AudioClip hello;
		public List<AudioClip> hardSex;
		public List<AudioClip> softSex;
		public List<AudioClip> stopSex;
		public List<AudioClip> hurt;
		public List<AudioClip> surprised;
		public List<AudioClip> touched;
	}

	[Header("Humans")]
	public List<HumanSounds> humanSoundbank;

	[Header("Furniture")]
	public AudioClip impactSound;

	[Header("Music")]
	public AudioClip menuMusic;
	public AudioClip gameMusic;

	public int GetVoiceRange()
	{
		return humanSoundbank.Count;
	}
}
