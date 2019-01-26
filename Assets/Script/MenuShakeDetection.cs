using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuShakeDetection : MonoBehaviour
{
    float accelerometerUpdateInterval = 1.0f/60.0f;
    public float lowPassKernelWidthInSeconds = 1.0f;
    public float shakeDetectionThreshold = 4.0f;

    private float lowPassFilterFactor;
    private Vector3 lowPassValue = Vector3.zero;
    private Vector3 acceleration;
    private Vector3 deltaAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        deltaAcceleration = acceleration - lowPassValue;
        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
