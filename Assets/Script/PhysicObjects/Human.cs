using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : PhysicStuff
{
	[SerializeField]
	private int identityRange;
	private int identity;

	private Material skin;

    // Start is called before the first frame update
	protected override void Start()
	{
		base.Start();
		identity = Random.Range(0, identityRange);

		skin = GetComponentInChildren<MeshRenderer>().material;

		skin.color = MessManager.Instance.colorContainer.GetRandColor();
	}

	// Update is called once per frame
	protected override void Update()
    {
		base.Update();   
    }

	protected override void OnCollisionEnter(Collision other)
	{
		base.OnCollisionEnter(other);
	}

	protected override void OnCollisionExit(Collision other)
	{
		base.OnCollisionExit(other);
	}
}
