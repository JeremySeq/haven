using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bacon : MonoBehaviour
{
    public float minimumY = -10f;

    private Transform[] children;
    private Vector2[] startPositions;
    private float[] startRotations;

    void Start()
    {
        children = GetComponentsInChildren<Transform>();
        Array.Resize(ref startPositions, children.Length);
        Array.Resize(ref startRotations, children.Length);
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == gameObject) continue;

            if (!children[i].TryGetComponent<Rigidbody2D>(out var rb)) continue;

            startPositions[i] = rb.position;
            startRotations[i] = rb.rotation;
        }
    }

    void Update()
    {
        Transform child = transform.GetChild(0);

        if (child.position.y < minimumY)
        {
            Reset();
        }
    }

    private void Reset()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == gameObject) continue;

            if (!children[i].TryGetComponent<Rigidbody2D>(out var rb)) continue;

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.position = startPositions[i];
            rb.rotation = startRotations[i];
        }
    }
}
