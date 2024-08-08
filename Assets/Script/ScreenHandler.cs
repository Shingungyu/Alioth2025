using UnityEngine;
using UnityEngine.UI;

public class ScreenHandler : MonoBehaviour
{
    // Dropdown 컴포넌트
    public Dropdown dropdown;

    void Start()
    {
        // Dropdown의 OnValueChanged 이벤트에 리스너 추가
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // Dropdown 값이 변경될 때 호출되는 메서드
    void OnDropdownValueChanged(int value)
    {
        // 선택된 옵션의 인덱스를 출력하거나 원하는 로직을 구현
        Debug.Log("Selected option: " + dropdown.options[value].text);

        // 예: 선택된 값에 따라 다른 동작 수행
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
