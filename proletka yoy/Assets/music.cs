using UnityEngine;

public class music : MonoBehaviour
{
    // Переменная для проверки, существует ли уже MusicManager
    private static music instance;

    // Этот метод вызывается перед началом игры
    void Awake()
    {
        // Проверяем, существует ли уже MusicManager
        if (instance == null)
        {
            // Если нет, назначаем этот объект как instance и сохраняем его между сценами
            instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожаем этот объект при загрузке новой сцены
        }
        else
        {
            // Если объект уже существует, уничтожаем дублирующий объект
            Destroy(gameObject);
        }
    }
}
