using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessManager : MonoBehaviour
{

	private static MessManager instance;
	public static MessManager Instance
	{
		get
		{

			if (!(instance is MessManager))
			{
				GameObject gO;
				instance = FindObjectOfType<MessManager>();

				if (!(instance is MessManager))
				{
					gO = Instantiate(Resources.Load("Prefab/Singletons/MessManager")) as GameObject;
					instance = gO.GetComponent<MessManager>();
				}
				else
				{
					gO = instance.gameObject;
				}
			}
			return instance;
		}
	}

	private bool pause;
	public ColorContainer colorContainer;

	private void Update()
	{
		if (!Input.GetKeyDown(KeyCode.P)) return;

		pause = !pause;
		Time.timeScale = pause ? 0f : 1f;
	}


}
