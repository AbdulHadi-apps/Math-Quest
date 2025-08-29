using UnityEngine;
using UnityEngine.UI;

public class SoundToggleSlider : MonoBehaviour
{
    public Image toggleCircleImage;

    public Color onColor = Color.green;
    public Color offColor = Color.red;

    public bool isOn = true; // ON by default

    void Start()
    {
        // Load saved sound state
        isOn = PlayerPrefs.GetInt("SoundOn", 1) == 1; // 1 = true (on), 0 = false (off)
        UpdateVisuals(isOn);

        if (SoundManager1.instance != null)
            SoundManager1.instance.ToggleSound(isOn);
    }

    public void Toggle()
    {
        isOn = !isOn;
        UpdateVisuals(isOn);

        // Save new state
        PlayerPrefs.SetInt("SoundOn", isOn ? 1 : 0);
        PlayerPrefs.Save();

        if (SoundManager1.instance != null)
            SoundManager1.instance.ToggleSound(isOn);
    }

    void UpdateVisuals(bool state)
    {
        toggleCircleImage.color = state ? onColor : offColor;
    }
}
