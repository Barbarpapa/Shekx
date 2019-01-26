using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "ColorContainer", menuName = "ColorContainer")]
public class ColorContainer : ScriptableObject
{

	[Header("Humans")]
	public Color[] colors;

	public Color GetRandColor()
	{
		int rand = Random.Range(0, colors.Length);
		return colors[rand];
	}
}
