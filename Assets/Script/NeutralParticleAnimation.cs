using DG.Tweening;
using UnityEngine;

public class NeutralParticleAnimation : MonoBehaviour
{
	private ParticleSystem[] particles;
	private Tween scaleTween;

	private void Awake()
	{
		particles = GetComponentsInChildren<ParticleSystem>();
		scaleTween = transform
			.DOScale(new Vector3(0.2f, 0.2f, 1f), particles[0].main.duration)
			.SetEase(Ease.InCubic)
			.From()
			.Pause()
			.SetAutoKill(false);
	}

	private void OnEnable()
	{
		scaleTween.Restart();
		for (int i = 0; i < particles.Length; i++)
		{
			particles[i].Play();
		}
	}

	private void OnParticleSystemStopped()
	{
		gameObject.SetActive(false);
	}
}
