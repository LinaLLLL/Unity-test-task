using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitGame : MonoBehaviour
{
    public GameObject creditsPanel;
    public float delayBeforeQuit = 10f;

    public void QuitApplication()
    {
        Debug.Log("������� ������ �� ����...");
        StartCoroutine(QuitRoutine());
    }

    private IEnumerator QuitRoutine()
    {
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);
            yield return null; // ��� ���� ����, ����� ������ ������������
        }

        Debug.Log($"���������� ����� ������������� {delayBeforeQuit} ������...");
        yield return new WaitForSeconds(delayBeforeQuit);

#if UNITY_EDITOR
        Debug.Log("����� �� ��������� Unity");
        EditorApplication.isPlaying = false;
#else
        Debug.Log("����� Application.Quit()");
        Application.Quit();

        yield return new WaitForSeconds(2f);

        Debug.Log("������� ���������� ��������");
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif
    }
}
