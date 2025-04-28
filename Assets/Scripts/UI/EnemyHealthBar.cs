using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image fillImage;
    public Canvas canvas;
    private Transform mainCam;

    public void UpdateHealthBar(float current, float max)
    {
        float fill = current / max;
        fillImage.fillAmount = fill;
        Debug.Log("Fill Amount: " + fill);
        canvas.enabled = fill < 1 && current > 0; // Hide if full or dead
    }

    void Start()
    {
        mainCam = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (mainCam != null)
            transform.LookAt(transform.position + mainCam.forward);
    }
}
