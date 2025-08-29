using UnityEngine;
using UnityEngine.UI;

public class MusicToggleSlider : MonoBehaviour
{
    public Image toggleCircleImage;

    public Color onColor = Color.green;
    public Color offColor = Color.red;

    public bool isOn = true;

    void Start()
    {
        // Load music state (default ON = 1)
        isOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        UpdateVisuals(isOn);

        if (AudioManager.instance != null)
            AudioManager.instance.SetMusic(isOn);
    }

    public void Toggle()
    {
        isOn = !isOn;
        UpdateVisuals(isOn);

        // Save new state
        PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
        PlayerPrefs.Save();

        if (AudioManager.instance != null)
            AudioManager.instance.SetMusic(isOn);
    }

    void UpdateVisuals(bool state)
    {
        toggleCircleImage.color = state ? onColor : offColor;
    }
}
