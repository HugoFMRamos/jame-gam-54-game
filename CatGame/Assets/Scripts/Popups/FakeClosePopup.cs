using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FakeClosePopup : PopupWindow
{
    public GameObject realButton;
    public GameObject fakeButton;
    public Transform buttonBoxTransform;
    public string[] closeTexts;
    private int numberOfFakeButtons;

    protected override void OnInit()
    {
        numberOfFakeButtons = Random.Range(1, 8);
        GenerateButtonLayout();
    }

    private void GenerateButtonLayout()
    {
        int realButtonPosition = Random.Range(0, numberOfFakeButtons - 1);
        for (int i = 0; i <= numberOfFakeButtons; i++) {
            if (i == realButtonPosition)
            {
                GameObject go = Instantiate(realButton, buttonBoxTransform);
                Button realBtn = go.GetComponentInChildren<Button>();

                realBtn.onClick.AddListener(() =>
                {
                    Complete();
                });
            }
            else
            {
                GameObject go = Instantiate(fakeButton, buttonBoxTransform);

                go.GetComponentInChildren<TextMeshProUGUI>().text = closeTexts[i];
                go.GetComponent<RectTransform>().sizeDelta = new Vector2(50f, 50f);
                
                Button fakeBtn = go.GetComponentInChildren<Button>();

                fakeBtn.onClick.AddListener(() =>
                {
                    Fail();
                });
            }
        }
    }

    protected override void OnComplete()
    {
        Debug.Log("Presses the correct button!");
    }
}
