using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AbilitySlotUI : MonoBehaviour
{
    public Image iconImage;
    public Image cooldownOverlay;

    private Ability ability;

    public TextMeshProUGUI keyLabel;

    public Image flashOverlay;
    public float flashDuration = 0.2f;
    private float flashTimer;


    public void Flash()
    {
        flashTimer = flashDuration;
        flashOverlay.color = Color.white;
        flashOverlay.enabled = true;
    } 

    public void SetKeyLabel(string key)
    {
        keyLabel.text = key;
    }

    public void SetAbility(Ability newAbility)
    {
        ability = newAbility;
        iconImage.sprite = ability.icon;
        iconImage.enabled = true;
    }

    void Update()
    {
        if (ability == null) return;

        // Cooldown logic...
        float t = Mathf.Clamp01(1 - ((Time.time - ability.LastUsed) / ability.cooldown));
        cooldownOverlay.fillAmount = t;
        cooldownOverlay.enabled = t > 0f;

        // Flash logic
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            float alpha = Mathf.Clamp01(flashTimer / flashDuration);
            flashOverlay.color = new Color(1f, 1f, 1f, alpha);
            if (flashTimer <= 0) flashOverlay.enabled = false;
        }
    }
}
