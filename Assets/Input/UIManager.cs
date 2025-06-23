using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AnyInputSceneChanger : MonoBehaviour
{
    [Tooltip("Имя сцены для загрузки")]
    public string nextSceneName = "Main_Menu"; // Укажите вашу сцену

    private void Update()
    {
        // Проверяем геймпад
        bool gamepadPressed = Gamepad.current != null && IsAnyGamepadButtonPressed();

        // Проверяем клавиатуру (любую клавишу)
        bool keyboardPressed = Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame;

        // Проверяем мышь (любую кнопку)
        bool mousePressed = Mouse.current != null &&
                          (Mouse.current.leftButton.wasPressedThisFrame ||
                           Mouse.current.rightButton.wasPressedThisFrame ||
                           Mouse.current.middleButton.wasPressedThisFrame);

        if ((gamepadPressed || keyboardPressed || mousePressed) && !string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("Обнаружен ввод! Переход на сцену: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private bool IsAnyGamepadButtonPressed()
    {
        // Проверяем все основные кнопки геймпада
        return Gamepad.current.buttonSouth.wasPressedThisFrame || // A (Xbox) / Cross (PS)
               Gamepad.current.buttonEast.wasPressedThisFrame ||  // B (Xbox) / Circle (PS)
               Gamepad.current.buttonWest.wasPressedThisFrame ||  // X (Xbox) / Square (PS)
               Gamepad.current.buttonNorth.wasPressedThisFrame || // Y (Xbox) / Triangle (PS)
               Gamepad.current.startButton.wasPressedThisFrame ||
               Gamepad.current.selectButton.wasPressedThisFrame ||
               Gamepad.current.leftShoulder.wasPressedThisFrame ||
               Gamepad.current.rightShoulder.wasPressedThisFrame ||
               Gamepad.current.dpad.up.wasPressedThisFrame ||
               Gamepad.current.dpad.down.wasPressedThisFrame ||
               Gamepad.current.dpad.left.wasPressedThisFrame ||
               Gamepad.current.dpad.right.wasPressedThisFrame;
    }
}