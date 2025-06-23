using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsPanel;

    void Start()
    {
        // � ������ ������ ���, ��������
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
