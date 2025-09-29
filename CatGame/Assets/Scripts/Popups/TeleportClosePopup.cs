using UnityEngine;
using UnityEngine.UI;

public class TeleportClosePopup : PopupWindow
{
    public Button closeButton;
    public RectTransform buttonParent;
    public GameObject fakeButtonPrefab;
    public int requiredClicks = 5;

    private int clicks = 0;

    protected override void OnInit()
    {
        closeButton.onClick.AddListener(OnRealButtonClicked);
    }

    private void OnRealButtonClicked()
    {
        clicks++;

        if (clicks >= requiredClicks)
        {
            Complete();
        }

        SpawnFakeButton(closeButton.GetComponent<RectTransform>().anchoredPosition);
        MoveButton(closeButton.GetComponent<RectTransform>());
    }

    private void SpawnFakeButton(Vector2 pos)
    {
        GameObject go = Instantiate(fakeButtonPrefab, buttonParent);
        RectTransform rt = go.GetComponent<RectTransform>();
        rt.anchoredPosition = pos;

        Button fakeBtn = go.GetComponentInChildren<Button>();
        fakeBtn.onClick.AddListener(() =>
        {
            Fail();
        });
    }

    private void MoveButton(RectTransform rt)
    {
        float x = Random.Range(-buttonParent.rect.width / 2f, buttonParent.rect.width / 2f);
        float y = Random.Range(-buttonParent.rect.height / 2f, buttonParent.rect.height / 2f);

        rt.anchoredPosition = new Vector2(x, y);
    }

    protected override void OnComplete()
    {
        Debug.Log("Chase button minigame complete!");
    }
}
