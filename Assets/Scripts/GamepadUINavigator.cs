using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GamepadUINavigator : MonoBehaviour
{
    public GameObject firstSelectedButton;

    void Start()
    {
        // Установить начальный фокус
        if (firstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    void Update()
    {
        // Если мышь двигается — снять фокус
        if (Mouse.current != null && Mouse.current.delta.ReadValue().magnitude > 0.1f)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        // Проверяем движение по клавиатуре (стрелки или WASD)
        bool keyboardMove = Keyboard.current != null && (
            Keyboard.current.upArrowKey.isPressed || Keyboard.current.downArrowKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed || Keyboard.current.rightArrowKey.isPressed ||
            Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed ||
            Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed
        );

        // Проверяем движение джойстика
        bool gamepadMove = Gamepad.current != null && Gamepad.current.leftStick.ReadValue().magnitude > 0.1f;

        // Если движение есть и сейчас нет выделенного объекта — установить фокус на первую кнопку
        if ((keyboardMove || gamepadMove) && EventSystem.current.currentSelectedGameObject == null && firstSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }
    }
}
