using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bacon : MonoBehaviour
{
    public float minimumY = -10f;

    private float pauseTimer;
    private bool needsResume;

    public int lives = 3;

    private Transform[] children;
    private Vector2[] startPositions;
    private float[] startRotations;

    void Start()
    {
        lives = 3;
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

        pauseTimer = 1.0f;
    }

    void Update()
    {
        if (pauseTimer >= 0.0f)
        {
            PausePhysics();
            pauseTimer -= Time.deltaTime;
        }
        else
        {
            ResumePhysics();
            if (CheckDeath())
            {
                Reset();
                lives -= 1;
                Debug.Log(lives);
                if (lives <= 0)
                {
                    GameManager.INSTANCE.cash -= GameManager.INSTANCE.currentFlip.GetComponent<Item>().Price;
                    SceneManager.LoadScene("SelectionScreen");
                }
                // TODO DIE
                // LOSE LIFE OR MONEY
            }
            else if (CheckWin())
            {
                Debug.Log("WIN!!!!");
                GameManager.INSTANCE.cash += GameManager.INSTANCE.currentFlip.GetComponent<Item>().Profit;
                SceneManager.LoadScene("SelectionScreen");

                // TODO WIN
                // GAIN MONEY
            }
        }
    }

    private bool CheckDeath()
    {
        return transform.GetChild(0).position.y < minimumY;
    }

    private bool CheckWin()
    {
        Vector2 average = Vector2.zero;
        float averageAngular = 0.0f;
        float n = 0.0f;

        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == gameObject) continue;

            if (!children[i].TryGetComponent<Rigidbody2D>(out var rb)) continue;

            average += new Vector2(Mathf.Abs(rb.linearVelocity.x), Mathf.Abs(rb.linearVelocity.y));
            averageAngular += Mathf.Abs(rb.angularVelocity);
            n += 1.0f;
        }

        average /= n;
        averageAngular /= n;
        // Debug.Log(average.magnitude);
        return average.magnitude < 1.0f && averageAngular < 1.0f && transform.GetChild(0).position.x > -2.0f;
    }

    private void PausePhysics()
    {
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == gameObject) continue;
            if (!children[i].TryGetComponent<Rigidbody2D>(out var rb)) continue;

            rb.isKinematic = true;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.position = startPositions[i];
            rb.rotation = startRotations[i];
        }

        needsResume = true;
    }

    private void ResumePhysics()
    {
        // if (!needsResume)
        //     return;

        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == gameObject) continue;
            if (!children[i].TryGetComponent<Rigidbody2D>(out var rb)) continue;

            rb.isKinematic = false;
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

        pauseTimer = 1.0f;
    }
}
