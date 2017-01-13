using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfDrawer : PropertyDrawer
{
    private bool _show;
    private FieldInfo _field;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return !_show ? 0.0f : base.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // obtain attribute
        var showIf = attribute as ShowIfAttribute;
        // obtain base class
        Object source = property.serializedObject.targetObject;
        System.Type eventOwnerType = source.GetType();

        if (showIf == null) return;

        // obtain field info reference
        string fieldName = showIf.FieldName;

        if (null == _field)
        {
            _field = eventOwnerType.GetField(fieldName, BindingFlags.Instance | BindingFlags.Static |
                                            BindingFlags.Public | BindingFlags.NonPublic);
        }

        // obtain value from the field on the actual base class
        if (null != _field && _field.FieldType == typeof(bool))
        {
            _show = (bool)_field.GetValue(source);
        }

        if (_show)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}
