using UnityEngine;
using UnityEngine.UI;

public class RamBar : MonoBehaviour
{
    public Image image;
    public Gradient ramBarGradient;

    void Start()
    {
        image.fillAmount = 0f;
    }

    public void SetRam(float ram, float maxRam)
    {
        float currentRam = ram / maxRam;

        image.fillAmount = currentRam;
        Color currentColor = ramBarGradient.Evaluate(currentRam);
        image.color = currentColor;
    }
}
