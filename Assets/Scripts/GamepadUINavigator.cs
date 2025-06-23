using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GamepadUINavigator : MonoBehaviour
{
    public GameObject firstSelectedButton;

    void Start()
    {
        // ���������� ��������� �����
        if (firstSelectedButton != null)
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    void Update()
    {
        // ���� ���� ��������� � ����� �����
        if (Mouse.current != null && Mouse.current.delta.ReadValue().magnitude > 0.1f)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        // ��������� �������� �� ���������� (������� ��� WASD)
        bool keyboardMove = Keyboard.current != null && (
            Keyboard.current.upArrowKey.isPressed || Keyboard.current.downArrowKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed || Keyboard.current.rightArrowKey.isPressed ||
            Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed ||
            Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed
        );

        // ��������� �������� ���������
        bool gamepadMove = Gamepad.current != null && Gamepad.current.leftStick.ReadValue().magnitude > 0.1f;

        // ���� �������� ���� � ������ ��� ����������� ������� � ���������� ����� �� ������ ������
        if ((keyboardMove || gamepadMove) && EventSystem.current.currentSelectedGameObject == null && firstSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }
    }
}
