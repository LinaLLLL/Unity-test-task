using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsPanel;

    void Start()
    {
        // В начале панели нет, скрываем
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        if (creditsPanel != null)
            creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
    }
}
