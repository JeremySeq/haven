using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class FlipperController : MonoBehaviour
{
    public Transform pivotPoint;
    private Vector3 rotationAxis = Vector3.back;
    private float currDeg = 0f;
    //private const float maxDeg = 30f;

    private const float maxDeg = 5f;
    private const float minDeg = -25f;

    private const float maxDegPerSecond = 260f;
    private const float currWeight = 2.5f;
    private const float speedCap = 7.0f;

    public Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(GameManager.INSTANCE.currentFlip, GameManager.INSTANCE.currentFlip.transform.position, GameManager.INSTANCE.currentFlip.transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed && currDeg <= maxDeg)
        {
            float nextDeg = (currDeg * currWeight + maxDeg) / (currWeight + 1);
            float deltaDeg = nextDeg - currDeg;
            deltaDeg = Mathf.Min(deltaDeg, speedCap);
            currDeg += deltaDeg;
            rb.MoveRotation(currDeg);
        }
        else
        {
            float nextDeg = (currDeg * currWeight + minDeg) / (currWeight + 1);
            float deltaDeg = nextDeg - currDeg;
            deltaDeg = Mathf.Max(deltaDeg, -speedCap);
            currDeg += deltaDeg;
            rb.MoveRotation(currDeg);
        }
    }
}
