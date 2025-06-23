using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class SingleEventSystemEnforcer : MonoBehaviour
{
    private static bool created = false;

    private void Awake()
    {
        if (created)
        {
            Destroy(gameObject);
            return;
        }

        created = true;
        DontDestroyOnLoad(gameObject);

        // Автоматическое создание недостающих компонентов
        if (!TryGetComponent<EventSystem>(out _))
            gameObject.AddComponent<EventSystem>();

        if (!TryGetComponent<InputSystemUIInputModule>(out _))
            gameObject.AddComponent<InputSystemUIInputModule>();
    }

    private void OnEnable()
    {
        // Удаляем дубликаты
        var eventSystems = FindObjectsOfType<EventSystem>();
        for (int i = 1; i < eventSystems.Length; i++)
        {
            if (eventSystems[i].gameObject != gameObject)
            {
                Debug.LogWarning($"Удален дубликат EventSystem на {eventSystems[i].gameObject.name}");
                Destroy(eventSystems[i].gameObject);
            }
        }
    }
}