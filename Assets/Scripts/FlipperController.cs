using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class FlipperController : MonoBehaviour
{
    public Transform pivotPoint;
    private Vector3 rotationAxis = Vector3.back;
    private float currentDegrees = 0f;
    private const float maxDegrees = 30f;

    private float degreesPerSecond = 0f;

    private const float maxDegreesPerSecond = 260f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed && currentDegrees <= maxDegrees)
        {
            degreesPerSecond = Mathf.Lerp(degreesPerSecond, maxDegreesPerSecond, 140*Time.deltaTime);
            //this.transform.rotation = Quaternion.Euler(0, 0, 45);
            float degreesToAdd = degreesPerSecond * Time.deltaTime;
            if (currentDegrees + degreesToAdd > maxDegrees) {
                degreesToAdd = maxDegrees - currentDegrees;
            }

            currentDegrees += degreesToAdd;
            this.transform.RotateAround(pivotPoint.position, rotationAxis, -degreesToAdd);
        } else
        {
            // slowly drop, linear
            if (currentDegrees > 0)
            {
                this.transform.RotateAround(pivotPoint.position, rotationAxis, maxDegreesPerSecond * Time.deltaTime);
                currentDegrees -= maxDegreesPerSecond * Time.deltaTime;
            }
        }
    }
}
    