using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField] private float xRotationForce = 3f;
	[SerializeField] private float zRotationForce = 3f;
	[SerializeField] private float cameraRotationSpeed = 0.2f;

	private Quaternion targetRotation;

    // Update is called once per frame
    private void Update()
    {
		Vector3 acc = Input.acceleration.normalized;
		acc = new Vector3 (acc.z * xRotationForce, 0, -acc.x * zRotationForce);
	    targetRotation
		    = Quaternion.Euler(acc);
		transform.rotation 
			= Quaternion.Lerp(transform.rotation, targetRotation, cameraRotationSpeed);
    }
}
