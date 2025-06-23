using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AnyGamepadButtonSceneChanger : MonoBehaviour
{
    [Header("���������")]
    public string nextSceneName = "MainMenu"; // ������� ���� ������� �����
    public float delayBeforeLoad = 0.5f; // �������� ����� ���������

    private void Update()
    {
        // ��������� ��������� �� �������
        if (Gamepad.current == null) return;

        // ��������� ������� ����� ������ �������� (����� ��������� ������/���������)
        if (IsAnyGamepadButtonPressed())
        {
            StartCoroutine(LoadSceneWithDelay());
        }
    }

    private bool IsAnyGamepadButtonPressed()
    {
        return
            // �������� ������
            Gamepad.current.buttonSouth.wasPressedThisFrame || // A (Xbox) / Cross (PS)
            Gamepad.current.buttonEast.wasPressedThisFrame || // B (Xbox) / Circle (PS)
            Gamepad.current.buttonWest.wasPressedThisFrame || // X (Xbox) / Square (PS)
            Gamepad.current.buttonNorth.wasPressedThisFrame || // Y (Xbox) / Triangle (PS)

            // ������ ����
            Gamepad.current.startButton.wasPressedThisFrame ||
            Gamepad.current.selectButton.wasPressedThisFrame ||

            // ������� � ��������
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
        // ����� �������� ������ ���������� ��� ��������
        yield return new WaitForSeconds(delayBeforeLoad);

        // ��������� �����
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