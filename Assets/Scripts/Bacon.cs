using UnityEngine;
using UnityEngine.SceneManagement;

public class Bacon : MonoBehaviour
{
    public float minimumY = -10f;

    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = Vector3.zero;
        Transform child = transform.GetChild(0);

        if (child.position.y < minimumY)
        {
            // offset = startPosition - child.position;
            // Debug.Log("y too low");
            // Debug.Log(child.position.y);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        // Debug.Log("current child position");
        // Debug.Log(child.position);
        // child.position = child.position + offset;
        // Debug.Log("offset");
        // Debug.Log(offset);
        // Debug.Log("new child position");
        // Debug.Log(child.position);


    }
}
