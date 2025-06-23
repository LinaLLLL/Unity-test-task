using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AnyGamepadButtonSceneChanger : MonoBehaviour
{
    [Header("Настройки")]
    public string nextSceneName = "MainMenu"; // Укажите вашу целевую сцену
    public float delayBeforeLoad = 0.5f; // Задержка перед переходом

    private void Update()
    {
        // Проверяем подключен ли геймпад
        if (Gamepad.current == null) return;

        // Проверяем нажатие ЛЮБОЙ кнопки геймпада (кроме сенсорной панели/триггеров)
        if (IsAnyGamepadButtonPressed())
        {
            StartCoroutine(LoadSceneWithDelay());
        }
    }

    private bool IsAnyGamepadButtonPressed()
    {
        return
            // Основные кнопки
            Gamepad.current.buttonSouth.wasPressedThisFrame || // A (Xbox) / Cross (PS)
            Gamepad.current.buttonEast.wasPressedThisFrame || // B (Xbox) / Circle (PS)
            Gamepad.current.buttonWest.wasPressedThisFrame || // X (Xbox) / Square (PS)
            Gamepad.current.buttonNorth.wasPressedThisFrame || // Y (Xbox) / Triangle (PS)

            // Кнопки меню
            Gamepad.current.startButton.wasPressedThisFrame ||
            Gamepad.current.selectButton.wasPressedThisFrame ||

            // Бамперы и триггеры
            Gamepad.current.leftShoulder.wasPressedThisFrame ||
            Gamepad.current.rightShoulder.wasPressedThisFrame ||

            // D-Pad
            Gamepad.current.dpad.up.wasPressedThisFrame ||
            Gamepad.current.dpad.down.wasPressedThisFrame ||
            Gamepad.current.dpad.left.wasPressedThisFrame ||
            Gamepad.current.dpad.right.wasPressedThisFrame;
    }

    private System.Collections.IEnumerator LoadSceneWithDelay()
    {
        // Можно добавить эффект затемнения или анимацию
        yield return new WaitForSeconds(delayBeforeLoad);

        // Загружаем сцену
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}