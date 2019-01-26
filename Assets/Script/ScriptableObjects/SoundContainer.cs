using UnityEngine;

[CreateAssetMenuAttribute(fileName = "SoundContainer", menuName = "CestLeSHEKS/SoundContainer")]
public class SoundContainer : ScriptableObject
{
	[Header("Humans")]
	public AudioClip[] voices;

	[Header("Furniture")]
	public AudioClip impactSound;

	public int GetVoiceRange()
	{
		return voices.Length;
	}
}
