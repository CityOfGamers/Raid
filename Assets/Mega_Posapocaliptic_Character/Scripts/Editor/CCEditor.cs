using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CharacterCustomizer))]
public class CCEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Help Text", MessageType.Info);
        DrawDefaultInspector();
    }
}
