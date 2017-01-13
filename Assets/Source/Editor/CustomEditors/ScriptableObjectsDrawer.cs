using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectsDrawer : Editor
{
    private Dictionary<string, SerializedProperty> _names = new Dictionary<string, SerializedProperty>();
    private Dictionary<SerializedProperty, Editor> _editors = new Dictionary<SerializedProperty, Editor>();
    private Dictionary<SerializedProperty, bool> _toggles = new Dictionary<SerializedProperty, bool>();

    public void DrawerEnable(SerializedObject obj, params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            // find properties
            SerializedProperty property = obj.FindProperty(propertyName);

            // reseting the editors will ensure they are written
            // to next time OnInspectorGUI is invoked
            if (_editors.ContainsKey(property))
            {
                _editors[property] = null;
            }
            else
            {
                _editors.Add(property, null);
            }

            if (!_names.ContainsKey(propertyName))
            {
                _names.Add(propertyName, property);
            }
        }
    }

    public void DrawerInspectorGUI(string propertyName, Object targetObject)
    {
        SerializedProperty property = null;

        if (_names.ContainsKey(propertyName))
        {
            property = _names[propertyName];
        }

        if (property != null && _editors.ContainsKey(property))
        {
            Editor editor = _editors[property];

            // create editor in case this doesn't exist yet
            if (editor == null)
            {
                _editors[property] = editor = CreateEditor(targetObject);
            }

            // draw scriptable object inspectors
            EditorGUILayout.PropertyField(property, true);

            if (!_toggles.ContainsKey(property))
            {
                _toggles.Add(property, false);
            }

            bool toggle = _toggles[property];
            // foldout to show scriptable object inspector
            toggle = EditorGUI.Foldout(GUILayoutUtility.GetLastRect(), toggle, "");

            // finally draw scriptable object inspector
            if (editor != null && toggle) editor.DrawDefaultInspector();

            _toggles[property] = toggle;
        }
    }
}

