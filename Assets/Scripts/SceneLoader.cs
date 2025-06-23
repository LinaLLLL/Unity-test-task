using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("Имя сцены для загрузки")]
    public string targetScene; // Имя сцены задаётся в Inspector

    // Вызывается при нажатии кнопки
    public void LoadTargetScene()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogError("Не указана сцена для загрузки!");
        }
    }
}
