using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(float))]
public class SliderCustomUI : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // �����̴��� �ּҰ��� �ִ밪 ���� (�ʿ信 ���� ����)
        float minValue = 0f;
        float maxValue = 1f;

        // float ���� �����ͼ� �����̴��� ǥ��
        float value = property.floatValue;
        value = EditorGUI.Slider(position, label, value, minValue, maxValue);
        property.floatValue = value;
    }
}