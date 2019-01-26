using UnityEngine;

[CreateAssetMenuAttribute(fileName = "SoundContainer", menuName = "SoundContainer")]
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
