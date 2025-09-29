using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] popUpPrefabs;
    public Transform canvasTransform;
    public UIController ui;
    public float ram = 0f;
    public float maxRam = 10f;
    public float ramIncreaseRate = 1f;

    void Start()
    {
        SpawnPopUp();
    }

    void Update()
    {
        ram += ramIncreaseRate * Time.deltaTime;
        ui.ramBar.SetRam(ram, maxRam);

        if (ram >= maxRam)
        {
            Debug.Log("You lose!");
        }
    }

    public void SpawnPopUp()
    {
        int i = Random.Range(0, popUpPrefabs.Length);
        GameObject go = Instantiate(popUpPrefabs[i], canvasTransform);
        go.GetComponent<PopupWindow>().Init(this);

        // Get the RectTransform (UI-specific transform)
        RectTransform rt = go.GetComponent<RectTransform>();

        // Random size within min/max bounds
        float width = Random.Range(700f, 800f);
        float height = Random.Range(300f, 400f);
        rt.sizeDelta = new Vector2(width, height);

        // Random position within parent canvas
        rt.anchoredPosition = new Vector2(
            Random.Range(-300f, 300f),
            Random.Range(-200f, 200f)
        );
    }

    public void OnPopUpClosed(PopupWindow popup, bool success)
    {
        if (!success)
        {
            ram += 1f;
        }
        else if (ram >= 1f)
        {
            ram -= 1f;
        }
        else
        {
            ram = 0f;
        }
    }
}