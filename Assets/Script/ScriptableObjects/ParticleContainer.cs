using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ParticleContainer", menuName = "CestLeSHEKS/ParticleContainer")]
public class ParticleContainer : ScriptableObject
{
	public ParticleSystem hurtParticles;
	public ParticleSystem loveParticles;
}
