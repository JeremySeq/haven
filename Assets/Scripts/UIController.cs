using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();

    [System.Serializable]
    public class FlipOption
    {
        public string Title;
        public int Price;
        public int Profit;
        public Texture2D Image;
    }


    //public List<FlipOption> flipOptions = new List<FlipOption>
    //{
    //    new FlipOption { Title = "Option 1", Price = 10, Profit = 5, Image = null },
    //    new FlipOption { Title = "Option 2", Price = 20, Profit = 10, Image = null },
    //    new FlipOption { Title = "Option 3", Price = 30, Profit = 15, Image = null }
    //};

    public List<GameObject> flipOptions = new List<GameObject>();

    public void Shuffle<T>(IList<T> list)
    {
        int count = list.Count;
        while (count > 1)
        {
            count--;
            int randomIndex = UnityEngine.Random.Range(0, count + 1);
            (list[randomIndex], list[count]) = (list[count], list[randomIndex]);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<GameObject> currentOptions = new List<GameObject>(flipOptions);
        currentOptions.RemoveAll(option => option.GetComponent<Item>().Price > GameManager.INSTANCE.cash);
        Shuffle(currentOptions);
        int i = 0;
        foreach (GameObject panel in panels)
        {
            if (i > panels.Count - 1)
            {
                break;
            }
            if (i > currentOptions.Count - 1)
            {
                panel.SetActive(false);
                continue;
            }
            GameObject option = currentOptions[i];
            panel.transform.Find("Title")?.GetComponent<TextMeshProUGUI>()?.SetText(option.GetComponent<Item>().Title);
            panel.transform.Find("Price")?.GetComponent<TextMeshProUGUI>()?.SetText("$" + option.GetComponent<Item>().Price.ToString());
            panel.transform.Find("Profit")?.GetComponent<TextMeshProUGUI>()?.SetText("$" + option.GetComponent<Item>().Profit.ToString());
            panel.transform.Find("Image").GetComponent<UnityEngine.UI.RawImage>().texture = option.GetComponent<Item>().Image;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select1()
    {
        GameManager.INSTANCE.currentFlip = panels[0];
    }

    public void Select2()
    {
        GameManager.INSTANCE.currentFlip = panels[1];
    }

    public void Select3()
    {
        GameManager.INSTANCE.currentFlip = panels[2];
    }

    public void Select4()
    {
        GameManager.INSTANCE.currentFlip = panels[3];
    }
}
