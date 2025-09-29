using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopup : PopupWindow
{
    public Image yesButton;
    public Image noButton;
    public TextMeshProUGUI yesText;
    public TextMeshProUGUI noText;
    public Color yesButtonColor;
    public Color noButtonColor;

    protected override void OnInit()
    {
        float changeButton = Random.value;
        if (changeButton < .125)
        {
            yesButton.color = noButtonColor;
            noButton.color = yesButtonColor;
        }
        else if (changeButton >= .125 && changeButton < .25)
        {
            yesText.text = "NO!";
            noText.text = "YES!";
        }

        Debug.Log("Choose the right Button!");
    }

    public void CorrectButton()
    {
        Complete();
    }

    public void WrongButton()
    {
        Fail();
    }

    protected override void OnComplete()
    {
        Debug.Log("You solved the popup!");
    }
}