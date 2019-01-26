using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SoundContainer))]
public class SoundContainerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (!GUILayout.Button("Populate Sounds")) return;

		string folderPath = "Assets/Sons";

	}
}
