using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Название сцены, на которую хотите переключиться
    public string nextSceneName;

    // Стартуем корутину для ожидания
    void Start()
    {
        // Запускаем корутину, которая подождет 60 секунд
        StartCoroutine(ChangeSceneAfterDelay(40f));
    }

    // Корусина для ожидания
    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        // Ждем заданное время
        yield return new WaitForSeconds(delay);

        // Загружаем следующую сцену
        SceneManager.LoadScene(nextSceneName);
    }
}
