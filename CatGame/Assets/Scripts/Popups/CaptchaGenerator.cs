using UnityEngine;

public static class CaptchaGenerator
{
    private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string GenerateCaptcha()
    {
        int length = Random.Range(4, 9);

        System.Text.StringBuilder captcha = new System.Text.StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            int index = Random.Range(0, chars.Length);
            captcha.Append(chars[index]);
        }

        return captcha.ToString();
    }
}