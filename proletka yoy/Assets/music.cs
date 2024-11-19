using UnityEngine;

public class music : MonoBehaviour
{
    // ���������� ��� ��������, ���������� �� ��� MusicManager
    private static music instance;

    // ���� ����� ���������� ����� ������� ����
    void Awake()
    {
        // ���������, ���������� �� ��� MusicManager
        if (instance == null)
        {
            // ���� ���, ��������� ���� ������ ��� instance � ��������� ��� ����� �������
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ���� ������ ��� �������� ����� �����
        }
        else
        {
            // ���� ������ ��� ����������, ���������� ����������� ������
            Destroy(gameObject);
        }
    }
}
