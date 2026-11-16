using UnityEngine;

public class Scroller : MonoBehaviour
{

    public float scrollSpeed = 200f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + scrollSpeed * Time.deltaTime, this.transform.position.z);
    }
}
