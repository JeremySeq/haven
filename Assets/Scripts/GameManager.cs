using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager INSTANCE = null;

    public int cash = 500;
    public UIController.FlipOption currentFlip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (INSTANCE != null && INSTANCE != this) {
            Destroy(gameObject);
            return;
        }
        INSTANCE = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
