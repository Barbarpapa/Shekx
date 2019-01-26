using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhysicsStuffData", menuName = "CestLeSHEKS/PhysicsStuffData")]
public class PhysicsStuffData : ScriptableObject
{
	[Header("Impact")]
	public float hurtImpactSpeed = 20f;
	public float softImpactSpeed = 2f;
}
