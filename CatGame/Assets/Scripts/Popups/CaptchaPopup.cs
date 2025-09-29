using TMPro;
using UnityEngine;

public class CaptchaPopup : PopupWindow
{
    public TextMeshProUGUI captchaText;
    public TMP_InputField inputField;
    private string captcha;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckInput(inputField.text);
        }
    }

    protected override void OnInit()
    {
        captcha = CaptchaGenerator.GenerateCaptcha();
        captchaText.text = captcha;
        
        Debug.Log("Solve the captcha!");
    }

    public void ConfirmButton()
    {
        CheckInput(inputField.text);
    }

    private void CheckInput(string input)
    {
        if (input == captcha)
        {
            Complete();
        }
        else
        {
            Fail();
        }
    }

    protected override void OnComplete()
    {
        Debug.Log("Captcha solved!");
    }
}
