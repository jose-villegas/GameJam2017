using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InputConfiguration))]
[CanEditMultipleObjects]
public class InputConfigurationEditor : ScriptableObjectsDrawer
{
    private SerializedProperty _controlType;

    public void OnEnable()
    {
        // find properties
        _controlType = serializedObject.FindProperty("ActiveControlType");
        // set scriptable objects drawers
        DrawerEnable(serializedObject, "KeyboardConfiguration", "GamepadConfiguration");
    }

    public override void OnInspectorGUI()
    {
        // the object this inspector is editing.
        var behaviour = target as InputConfiguration;
        // update values
        serializedObject.Update();
        EditorGUILayout.PropertyField(_controlType, true);

        // draw scriptable object inspectors
        if (behaviour != null)
        {
            DrawerInspectorGUI("GamepadConfiguration", behaviour.GamepadConfiguration);
            DrawerInspectorGUI("KeyboardConfiguration", behaviour.KeyboardConfiguration);
        }

        // apply changes
        serializedObject.ApplyModifiedProperties();
    }
}

