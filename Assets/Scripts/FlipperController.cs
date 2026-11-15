using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class FlipperController : MonoBehaviour
{
    public Transform pivotPoint;
    private Vector3 rotationAxis = Vector3.back;
    private float currentDegrees = 0f;
    //private const float maxDegrees = 30f;

    private const float maxDegrees = 5f;
    private const float minDegrees = -25f;

    private const float maxDegreesPerSecond = 260f;

    public Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed && currentDegrees <= maxDegrees)
        {
            currentDegrees = (currentDegrees * 2 + maxDegrees) / 3;

            rb.MoveRotation(currentDegrees);
        } else
        {
            // slowly drop, linear
            if (currentDegrees > minDegrees)
            {
                currentDegrees -= maxDegreesPerSecond * Time.deltaTime;
                rb.MoveRotation(currentDegrees);
            }
        }
    }
}
    