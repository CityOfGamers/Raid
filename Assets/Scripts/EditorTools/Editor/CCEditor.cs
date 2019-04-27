using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CCGui))]
public class CCEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CCGui menu = (CCGui)target;

        if (GUILayout.Button("FadeOut"))
        {
            menu.FadeGUI(true);
        }
        if (GUILayout.Button("FadeIn"))
        {
            menu.FadeGUI(false);
        }
    }
}
