using UnityEngine;

public class MenuButtonHandler : MonoBehaviour
{
    public GameObject soundSettingsPanel;

    public void ToggleSoundSettings()
    {
        if (soundSettingsPanel != null)
        {
            bool isActive = soundSettingsPanel.activeSelf;
            soundSettingsPanel.SetActive(!isActive);
        }
    }
}
