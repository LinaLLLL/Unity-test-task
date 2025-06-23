using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("��� ����� ��� ��������")]
    public string targetScene; // ��� ����� ������� � Inspector

    // ���������� ��� ������� ������
    public void LoadTargetScene()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogError("�� ������� ����� ��� ��������!");
        }
    }
}
