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

    private const float maxDegreesPerSecond = 160f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed && currentDegrees < maxDegrees)
        {
            Debug.Log("mouse pressed");
            degreesPerSecond = Mathf.Lerp(degreesPerSecond, maxDegreesPerSecond, 15*Time.deltaTime);
            //this.transform.rotation = Quaternion.Euler(0, 0, 45);
            this.transform.RotateAround(pivotPoint.position, rotationAxis, -degreesPerSecond * Time.deltaTime);
            currentDegrees += degreesPerSecond * Time.deltaTime;
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
    