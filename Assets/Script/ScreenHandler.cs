using UnityEngine;
using UnityEngine.UI;

public class ScreenHandler : MonoBehaviour
{
    // Dropdown ������Ʈ
    public Dropdown dropdown;

    void Start()
    {
        // Dropdown�� OnValueChanged �̺�Ʈ�� ������ �߰�
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // Dropdown ���� ����� �� ȣ��Ǵ� �޼���
    void OnDropdownValueChanged(int value)
    {
        // ���õ� �ɼ��� �ε����� ����ϰų� ���ϴ� ������ ����
        Debug.Log("Selected option: " + dropdown.options[value].text);

        // ��: ���õ� ���� ���� �ٸ� ���� ����
        switch (value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
                break;

            case 1:
                Screen.SetResolution(2560, 1440, FullScreenMode.Windowed);
                break;

            case 2:
                Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
                break;
        }
    }
}
