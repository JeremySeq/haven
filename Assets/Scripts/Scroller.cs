using UnityEngine;
using UnityEngine.SceneManagement;

public class Scroller : MonoBehaviour
{

    public float scrollSpeed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + scrollSpeed * Time.deltaTime, this.transform.localPosition.z);

        if (this.transform.localPosition.y >= 250f)
        {
            SceneManager.LoadScene("SelectionScreen");
        }
    }
}
