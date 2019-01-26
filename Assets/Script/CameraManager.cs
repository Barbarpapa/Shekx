using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField] private float cameraRotationForce = 3f;
	[SerializeField] private float cameraRotationSpeed = 0.2f;

	private Quaternion targetRotation;

    // Update is called once per frame
    private void Update()
    {
	    targetRotation
		    = Quaternion.Euler(Quaternion.AngleAxis(90f, Vector3.down)
		                       * Input.acceleration.normalized * cameraRotationForce);
		transform.rotation 
			= Quaternion.Lerp(transform.rotation, targetRotation, cameraRotationSpeed);
    }
}
