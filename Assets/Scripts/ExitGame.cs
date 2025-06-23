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
        Debug.Log("Попытка выхода из игры...");
        StartCoroutine(QuitRoutine());
    }

    private IEnumerator QuitRoutine()
    {
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);
            yield return null; // ждём один кадр, чтобы панель отобразилась
        }

        Debug.Log($"Показываем экран благодарности {delayBeforeQuit} секунд...");
        yield return new WaitForSeconds(delayBeforeQuit);

#if UNITY_EDITOR
        Debug.Log("Выход из редактора Unity");
        EditorApplication.isPlaying = false;
#else
        Debug.Log("Вызов Application.Quit()");
        Application.Quit();

        yield return new WaitForSeconds(2f);

        Debug.Log("Жесткое завершение процесса");
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif
    }
}
