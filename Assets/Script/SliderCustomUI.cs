using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(float))]
public class SliderCustomUI : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // 슬라이더의 최소값과 최대값 설정 (필요에 따라 변경)
        float minValue = 0f;
        float maxValue = 1f;

        // float 값을 가져와서 슬라이더로 표시
        float value = property.floatValue;
        value = EditorGUI.Slider(position, label, value, minValue, maxValue);
        property.floatValue = value;
    }
}