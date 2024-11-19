using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // �������� �����, �� ������� ������ �������������
    public string nextSceneName;

    // �������� �������� ��� ��������
    void Start()
    {
        // ��������� ��������, ������� �������� 60 ������
        StartCoroutine(ChangeSceneAfterDelay(40f));
    }

    // �������� ��� ��������
    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        // ���� �������� �����
        yield return new WaitForSeconds(delay);

        // ��������� ��������� �����
        SceneManager.LoadScene(nextSceneName);
    }
}
