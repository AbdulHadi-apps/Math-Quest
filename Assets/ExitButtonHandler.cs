using UnityEngine;

public class ExitButtonHandler : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject winUIPanel;


    public void CloseSettingsPanel()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    public void CloseWinUI()
    {
        if (winUIPanel != null)
        {
            winUIPanel.SetActive(false);
        }
    }
}
