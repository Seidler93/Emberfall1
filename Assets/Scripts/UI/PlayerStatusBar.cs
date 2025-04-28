using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBar : MonoBehaviour
{
    public Image healthFillImage;
    public Canvas canvas;
    private Transform mainCam;

    public void UpdateHealthBar(float current, float max)
    {
        float fill = current / max;
        healthFillImage.fillAmount = fill;
    }
    
}
